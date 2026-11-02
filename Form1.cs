using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp2
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=autoservice.db;Version=3;";
        private Dictionary<string, List<string>> brandsDir = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> modelsDir = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            cmbVehicleType.SelectedIndexChanged += cmbVehicleType_SelectedIndexChanged;
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            btnAddClient.Click += btnAddClient_Click;
            btnEditClient.Click += btnEditClient_Click;
            btnDeleteClient.Click += btnDeleteClient_Click;
            btnCreateOrder.Click += btnCreateOrder_Click;
            dgvClients.CellClick += dgvClients_CellClick;

            btnAddPrice.Click += btnAddPrice_Click;
            btnEditPrice.Click += btnEditPrice_Click;
            btnDeletePrice.Click += btnDeletePrice_Click;
            dgvPriceList.CellClick += dgvPriceList_CellClick;

            cmbBrand.KeyDown += cmbBrand_KeyDown;
            cmbModel.KeyDown += cmbModel_KeyDown;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            InitDatabase();
            LoadDirectories();
            SetupUI();
            RefreshPriceListGrid();
            RefreshOrdersHistoryGrid();
        }

        private void InitDatabase()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Clients (Id INTEGER PRIMARY KEY AUTOINCREMENT, FullName TEXT, Phone TEXT, Comment TEXT);
                    CREATE TABLE IF NOT EXISTS Vehicles (Id INTEGER PRIMARY KEY AUTOINCREMENT, ClientId INTEGER, VehicleType TEXT, Brand TEXT, Model TEXT, LicensePlate TEXT, Mileage INTEGER, Comment TEXT);
                    CREATE TABLE IF NOT EXISTS PriceList (Id INTEGER PRIMARY KEY AUTOINCREMENT, VehicleType TEXT, WorkCategory TEXT, WorkName TEXT, Price REAL);
                    CREATE TABLE IF NOT EXISTS WorkOrders (Id INTEGER PRIMARY KEY AUTOINCREMENT, ClientId INTEGER, VehicleId INTEGER, IssueDescription TEXT, Status TEXT, AdditionalWorks TEXT, Materials TEXT, MainWork TEXT);
                    CREATE TABLE IF NOT EXISTS DictionaryBrands (Id INTEGER PRIMARY KEY AUTOINCREMENT, VehicleType TEXT, BrandName TEXT);
                    CREATE TABLE IF NOT EXISTS DictionaryModels (Id INTEGER PRIMARY KEY AUTOINCREMENT, BrandName TEXT, ModelName TEXT);";
                using (var cmd = new SQLiteCommand(sql, conn)) { cmd.ExecuteNonQuery(); }

                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE WorkOrders ADD COLUMN MainWork TEXT;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }

                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM PriceList", conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        string fillPrice = @"
                            INSERT INTO PriceList (VehicleType, WorkCategory, WorkName, Price) VALUES 
                            ('Легковой автомобиль', 'Двигатель', 'Замена масла и фильтра (1500 руб.)', 1500),
                            ('Легковой автомобиль', 'Ходовая', 'Замена передних тормозных колодок (1800 руб.)', 1800),
                            ('Легковой автомобиль', 'Ходовая', 'Замена амортизатора (2500 руб.)', 2500),
                            ('Легковой автомобиль', 'Тормозная система', 'Прокачка тормозов (1200 руб.)', 1200),
                            ('Легковой автомобиль', 'Диагностика', 'Компьютерная диагностика ЭБУ (1000 руб.)', 1000),
                            ('Грузовой автомобиль', 'Двигатель', 'Капитальный ремонт ДВС (45000 руб.)', 45000),
                            ('Грузовой автомобиль', 'Двигатель', 'Замена масла в грузовом ДВС (5000 руб.)', 5000),
                            ('Грузовой автомобиль', 'Трансмиссия', 'Замена сцепления (15000 руб.)', 15000),
                            ('Коммерческий транспорт', 'Подвеска', 'Замена рессоры (4000 руб.)', 4000),
                            ('Коммерческий транспорт', 'Электрика', 'Диагностика проводки (3000 руб.)', 3000),
                            ('Спец техника', 'Гидравлика', 'Замена гидравлического шланга (3500 руб.)', 3500),
                            ('Спец техника', 'ТО', 'Комплексное техническое обслуживание (12000 руб.)', 12000),
                            ('Мото техника', 'Двигатель', 'Синхронизация карбюраторов (4000 руб.)', 4000),
                            ('Мото техника', 'ТО', 'Замена масла и смазка цепи (1500 руб.)', 1500);";
                        using (var insertCmd = new SQLiteCommand(fillPrice, conn)) { insertCmd.ExecuteNonQuery(); }
                    }
                }
            }
        }

        private void LoadDirectories()
        {
            string[] types = { "Легковой автомобиль", "Грузовой автомобиль", "Коммерческий транспорт", "Спец техника", "Мото техника" };
            cmbPriceVehicleType.Items.AddRange(types);

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM DictionaryBrands", conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        FillDefaultDirectories(conn);
                    }
                }

                foreach (var type in types)
                {
                    brandsDir[type] = new List<string>();
                    using (var cmd = new SQLiteCommand("SELECT BrandName FROM DictionaryBrands WHERE VehicleType = @t", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", type);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) brandsDir[type].Add(reader["BrandName"].ToString() ?? "");
                        }
                    }

                    foreach (var brand in brandsDir[type])
                    {
                        if (!modelsDir.ContainsKey(brand))
                        {
                            modelsDir[brand] = new List<string>();
                            using (var cmd = new SQLiteCommand("SELECT ModelName FROM DictionaryModels WHERE BrandName = @b", conn))
                            {
                                cmd.Parameters.AddWithValue("@b", brand);
                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read()) modelsDir[brand].Add(reader["ModelName"].ToString() ?? "");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FillDefaultDirectories(SQLiteConnection conn)
        {
            using (var transaction = conn.BeginTransaction())
            {
                var defaultBrands = new Dictionary<string, List<string>>
                {
                    { "Легковой автомобиль", new List<string> { "Toyota", "BMW", "Mercedes-Benz", "Audi", "Lada", "Hyundai", "Kia", "Nissan", "Volkswagen", "Ford", "Mazda", "Honda" } },
                    { "Грузовой автомобиль", new List<string> { "KAMAZ", "Volvo", "MAN", "Scania", "MAZ", "DAF" } },
                    { "Коммерческий транспорт", new List<string> { "GAZ", "UAZ", "Ford Commercial" } },
                    { "Спец техника", new List<string> { "JCB", "CAT", "Komatsu", "MTZ", "Bobcat", "John Deere" } },
                    { "Мото техника", new List<string> { "Yamaha", "Honda", "Kawasaki", "Suzuki", "BMW Motorrad", "Harley-Davidson" } }
                };

                var defaultModels = new Dictionary<string, List<string>>
                {
                    { "Toyota", new List<string> { "Camry", "RAV4", "Corolla", "Land Cruiser", "Prado", "Hilux" } },
                    { "BMW", new List<string> { "3 Series", "5 Series", "7 Series", "X3", "X5", "X6" } },
                    { "Mercedes-Benz", new List<string> { "C-Class", "E-Class", "S-Class", "GLC", "GLE", "G-Class" } },
                    { "Audi", new List<string> { "A4", "A6", "A8", "Q5", "Q7", "Q8" } },
                    { "Lada", new List<string> { "Vesta", "Granta", "Niva Legend", "Niva Travel", "Largus" } },
                    { "Hyundai", new List<string> { "Solaris", "Creta", "Tucson", "Santa Fe", "Elantra", "Sonata" } },
                    { "Kia", new List<string> { "Rio", "Sportage", "Ceed", "Optima", "K5", "Sorento" } },
                    { "Nissan", new List<string> { "Qashqai", "X-Trail", "Juke", "Almera", "Teana" } },
                    { "Volkswagen", new List<string> { "Polo", "Tiguan", "Passat", "Touareg", "Golf", "Jetta" } },
                    { "Ford", new List<string> { "Focus", "Mondeo", "Kuga", "Fiesta", "Explorer" } },
                    { "Mazda", new List<string> { "Mazda 3", "Mazda 6", "CX-5", "CX-9" } },
                    { "Honda", new List<string> { "Civic", "CR-V", "Accord", "Fit", "Pilot" } },
                    { "KAMAZ", new List<string> { "5490", "43118", "65115", "6520" } },
                    { "Volvo", new List<string> { "FH12", "FH16", "FM", "FMX" } },
                    { "MAN", new List<string> { "TGX", "TGS", "TGM", "TGL" } },
                    { "Scania", new List<string> { "R-Series", "G-Series", "P-Series", "S-Series" } },
                    { "MAZ", new List<string> { "5440", "6430", "5550" } },
                    { "DAF", new List<string> { "XF105", "XF106", "CF" } },
                    { "GAZ", new List<string> { "Gazelle Next", "Gazelle Business", "Sobol", "Lawn Next" } },
                    { "UAZ", new List<string> { "Profi", "Loaf (Buhanka)", "Hunter", "Patriot" } },
                    { "Ford Commercial", new List<string> { "Transit", "Tourneo Custom" } },
                    { "JCB", new List<string> { "3CX", "4CX", "531-70" } },
                    { "CAT", new List<string> { "428", "320", "D6N" } },
                    { "Komatsu", new List<string> { "PC210", "WB93R", "D65" } },
                    { "MTZ", new List<string> { "Belarus-82.1", "Belarus-1221" } },
                    { "Bobcat", new List<string> { "S530", "S190", "T590" } },
                    { "John Deere", new List<string> { "6130M", "8335R", "325SL" } },
                    { "Yamaha", new List<string> { "YZF-R1", "YZF-R6", "FZ6", "MT-07" } },
                    { "Kawasaki", new List<string> { "Ninja ZX-6R", "Ninja ZX-10R", "Z900", "Vulcan S" } },
                    { "Suzuki", new List<string> { "GSX-R1000", "Hayabusa", "SV650", "V-Strom" } },
                    { "BMW Motorrad", new List<string> { "R1250GS", "S1000RR", "F850GS" } },
                    { "Harley-Davidson", new List<string> { "Sportster 883", "Fat Boy", "Iron 1200" } }
                };

                foreach (var bPair in defaultBrands)
                {
                    foreach (var bName in bPair.Value)
                    {
                        using (var cmd = new SQLiteCommand("INSERT INTO DictionaryBrands (VehicleType, BrandName) VALUES (@t, @n)", conn))
                        {
                            cmd.Parameters.AddWithValue("@t", bPair.Key);
                            cmd.Parameters.AddWithValue("@n", bName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                foreach (var mPair in defaultModels)
                {
                    foreach (var mName in mPair.Value)
                    {
                        using (var cmd = new SQLiteCommand("INSERT INTO DictionaryModels (BrandName, ModelName) VALUES (@b, @n)", conn))
                        {
                            cmd.Parameters.AddWithValue("@b", mPair.Key);
                            cmd.Parameters.AddWithValue("@n", mName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                transaction.Commit();
            }
        }

        private void SetupUI()
        {
            cmbVehicleType.Items.AddRange(new string[] { "Легковой автомобиль", "Грузовой автомобиль", "Коммерческий транспорт", "Спец техника", "Мото техника" });
            cmbOrderStatus.Items.AddRange(new string[] { "Принят", "В работе", "Выполнен", "Оплачен" });
            cmbOrderStatus.SelectedIndex = 0;
            cmbBrand.DropDownStyle = ComboBoxStyle.DropDown;
            cmbModel.DropDownStyle = ComboBoxStyle.DropDown;
            RefreshClientsGrid();
        }

        private void cmbVehicleType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            cmbBrand.Items.Clear();
            cmbModel.Items.Clear();
            cmbPriceWorks.Items.Clear();

            string? selectedType = cmbVehicleType.SelectedItem?.ToString();
            if (selectedType != null)
            {
                if (brandsDir.ContainsKey(selectedType))
                {
                    cmbBrand.Items.AddRange(brandsDir[selectedType].ToArray());
                }
                UpdateWorksCombo(selectedType);
            }
        }

        private void UpdateWorksCombo(string vehicleType)
        {
            cmbPriceWorks.Items.Clear();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT WorkName FROM PriceList WHERE VehicleType = @vType";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@vType", vehicleType);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbPriceWorks.Items.Add(reader["WorkName"].ToString() ?? "");
                        }
                    }
                }
            }
            if (cmbPriceWorks.Items.Count > 0) cmbPriceWorks.SelectedIndex = 0;
        }

        private void cmbBrand_SelectedIndexChanged(object? sender, EventArgs e)
        {
            cmbModel.Items.Clear();
            string? selectedBrand = cmbBrand.SelectedItem?.ToString();
            if (selectedBrand != null && modelsDir.ContainsKey(selectedBrand))
            {
                cmbModel.Items.AddRange(modelsDir[selectedBrand].ToArray());
            }
        }

        private void cmbBrand_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string newBrand = cmbBrand.Text.Trim();
                string? selectedType = cmbVehicleType.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(newBrand) || string.IsNullOrEmpty(selectedType)) return;

                if (!brandsDir[selectedType].Contains(newBrand))
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand("INSERT INTO DictionaryBrands (VehicleType, BrandName) VALUES (@t, @n)", conn))
                        {
                            cmd.Parameters.AddWithValue("@t", selectedType);
                            cmd.Parameters.AddWithValue("@n", newBrand);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    brandsDir[selectedType].Add(newBrand);
                    if (!modelsDir.ContainsKey(newBrand)) modelsDir[newBrand] = new List<string>();
                    cmbBrand.Items.Add(newBrand);
                    cmbBrand.SelectedItem = newBrand;
                    MessageBox.Show($"Марка '{newBrand}' успешно добавлена!");
                }
            }
        }

        private void cmbModel_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string newModel = cmbModel.Text.Trim();
                string selectedBrand = cmbBrand.Text.Trim();
                if (string.IsNullOrEmpty(newModel) || string.IsNullOrEmpty(selectedBrand)) return;

                if (!modelsDir.ContainsKey(selectedBrand)) modelsDir[selectedBrand] = new List<string>();
                if (!modelsDir[selectedBrand].Contains(newModel))
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand("INSERT INTO DictionaryModels (BrandName, ModelName) VALUES (@b, @n)", conn))
                        {
                            cmd.Parameters.AddWithValue("@b", selectedBrand);
                            cmd.Parameters.AddWithValue("@n", newModel);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    modelsDir[selectedBrand].Add(newModel);
                    cmbModel.Items.Add(newModel);
                    cmbModel.SelectedItem = newModel;
                    MessageBox.Show($"Модель '{newModel}' успешно добавлена для марки {selectedBrand}!");
                }
            }
        }

        private void btnAddClient_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("Заполните ФИО клиента!");
                return;
            }
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Clients (FullName, Phone, Comment) VALUES (@name, @phone, @comment)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtClientName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtClientPhone.Text);
                    cmd.Parameters.AddWithValue("@comment", txtClientComment.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            ClearClientInputs();
            RefreshClientsGrid();
        }

        private void dgvClients_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                txtClientName.Text = dgvClients.CurrentRow.Cells["FullName"].Value?.ToString();
                txtClientPhone.Text = dgvClients.CurrentRow.Cells["Phone"].Value?.ToString();
                txtClientComment.Text = dgvClients.CurrentRow.Cells["Comment"].Value?.ToString();
            }
        }

        private void btnEditClient_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента в таблице для редактирования!");
                return;
            }
            long id = Convert.ToInt64(dgvClients.CurrentRow.Cells["Id"].Value);
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Clients SET FullName = @name, Phone = @phone, Comment = @comment WHERE Id = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtClientName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtClientPhone.Text);
                    cmd.Parameters.AddWithValue("@comment", txtClientComment.Text);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            ClearClientInputs();
            RefreshClientsGrid();
            MessageBox.Show("Данные клиента успешно обновлены!");
        }

        private void btnDeleteClient_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента в таблице для удаления!");
                return;
            }
            long id = Convert.ToInt64(dgvClients.CurrentRow.Cells["Id"].Value);
            var result = MessageBox.Show("Вы уверены, что хотите удалить клиента и все его ТС?", "Удаление", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("DELETE FROM Clients WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SQLiteCommand("DELETE FROM Vehicles WHERE ClientId = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                ClearClientInputs();
                RefreshClientsGrid();
            }
        }

        private void btnAddPrice_Click(object? sender, EventArgs e)
        {
            if (cmbPriceVehicleType.SelectedItem == null || string.IsNullOrWhiteSpace(txtPriceWorkName.Text) || !double.TryParse(txtPriceValue.Text, out double p))
            {
                MessageBox.Show("Заполните корректно все поля новой услуги!");
                return;
            }
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO PriceList (VehicleType, WorkCategory, WorkName, Price) VALUES (@type, @cat, @name, @price)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@type", cmbPriceVehicleType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cat", txtPriceCategory.Text);
                    cmd.Parameters.AddWithValue("@name", $"{txtPriceWorkName.Text} ({p} руб.)");
                    cmd.Parameters.AddWithValue("@price", p);
                    cmd.ExecuteNonQuery();
                }
            }
            ClearPriceInputs();
            RefreshPriceListGrid();
        }

        private void dgvPriceList_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvPriceList.CurrentRow != null)
            {
                cmbPriceVehicleType.SelectedItem = dgvPriceList.CurrentRow.Cells["Тип ТС"].Value?.ToString();
                txtPriceCategory.Text = dgvPriceList.CurrentRow.Cells["Категория"].Value?.ToString();
                string rawName = dgvPriceList.CurrentRow.Cells["Наименование работы"].Value?.ToString() ?? "";
                if (rawName.Contains(" (")) rawName = rawName.Substring(0, rawName.LastIndexOf(" ("));
                txtPriceWorkName.Text = rawName;
                txtPriceValue.Text = dgvPriceList.CurrentRow.Cells["Цена (руб.)"].Value?.ToString();
            }
        }

        private void btnEditPrice_Click(object? sender, EventArgs e)
        {
            if (dgvPriceList.CurrentRow == null) return;
            long id = 0;
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string findId = "SELECT Id FROM PriceList WHERE VehicleType = @t AND WorkName = @n";
                using (var cmd = new SQLiteCommand(findId, conn))
                {
                    cmd.Parameters.AddWithValue("@t", dgvPriceList.CurrentRow.Cells["Тип ТС"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@n", dgvPriceList.CurrentRow.Cells["Наименование работы"].Value?.ToString());
                    id = Convert.ToInt64(cmd.ExecuteScalar());
                }
                if (id > 0 && double.TryParse(txtPriceValue.Text, out double p))
                {
                    string sql = "UPDATE PriceList SET VehicleType = @t, WorkCategory = @c, WorkName = @n, Price = @p WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", cmbPriceVehicleType.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@c", txtPriceCategory.Text);
                        cmd.Parameters.AddWithValue("@n", $"{txtPriceWorkName.Text} ({p} руб.)");
                        cmd.Parameters.AddWithValue("@p", p);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            ClearPriceInputs();
            RefreshPriceListGrid();
            MessageBox.Show("Позиция прайса обновлена!");
        }

        private void btnDeletePrice_Click(object? sender, EventArgs e)
        {
            if (dgvPriceList.CurrentRow == null) return;
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM PriceList WHERE VehicleType = @t AND WorkName = @n";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@t", dgvPriceList.CurrentRow.Cells["Тип ТС"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@n", dgvPriceList.CurrentRow.Cells["Наименование работы"].Value?.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            ClearPriceInputs();
            RefreshPriceListGrid();
        }

        private void RefreshClientsGrid()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter("SELECT * FROM Clients", conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvClients.DataSource = dt;
                }
            }
        }

        private void RefreshPriceListGrid()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter("SELECT VehicleType as 'Тип ТС', WorkCategory as 'Категория', WorkName as 'Наименование работы', Price as 'Цена (руб.)' FROM PriceList", conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPriceList.DataSource = dt;
                }
            }
            if (cmbVehicleType.SelectedItem != null) UpdateWorksCombo(cmbVehicleType.SelectedItem.ToString()!);
        }

        private void RefreshOrdersHistoryGrid()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT
                        w.Id as 'Номер заказ-наряда',
                        c.FullName as 'ФИО Клиента',
                        v.Brand || ' ' || v.Model as 'Автомобиль',
                        v.LicensePlate as 'Гос. номер',
                        w.MainWork as 'Основная работа',
                        w.AdditionalWorks as 'Доп. работы',
                        w.Materials as 'Материалы',
                        w.Status as 'Статус заказа'
                    FROM WorkOrders w
                    LEFT JOIN Clients c ON w.ClientId = c.Id
                    LEFT JOIN Vehicles v ON w.VehicleId = v.Id";
                using (var adapter = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrdersHistory.DataSource = dt;
                }
            }
        }

        private void ClearClientInputs()
        {
            txtClientName.Clear();
            txtClientPhone.Clear();
            txtClientComment.Clear();
        }

        private void ClearPriceInputs()
        {
            txtPriceCategory.Clear();
            txtPriceWorkName.Clear();
            txtPriceValue.Clear();
        }

        private void btnCreateOrder_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Сначала выберите клиента на первой вкладке!");
                return;
            }
            string selectedBrand = cmbBrand.Text.Trim();
            string selectedModel = cmbModel.Text.Trim();
            if (cmbVehicleType.SelectedItem == null || string.IsNullOrEmpty(selectedBrand) || string.IsNullOrEmpty(selectedModel))
            {
                MessageBox.Show("Заполните все параметры автомобиля!");
                return;
            }
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        long clientId = Convert.ToInt64(dgvClients.CurrentRow.Cells["Id"].Value);
                        string insertVehicle = @"INSERT INTO Vehicles (ClientId, VehicleType, Brand, Model, LicensePlate, Mileage, Comment)
                            VALUES (@cId, @vType, @brand, @model, @plate, @mileage, @comment); SELECT last_insert_rowid();";
                        long vehicleId;
                        using (var cmd = new SQLiteCommand(insertVehicle, conn))
                        {
                            cmd.Parameters.AddWithValue("@cId", clientId);
                            cmd.Parameters.AddWithValue("@vType", cmbVehicleType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@brand", selectedBrand);
                            cmd.Parameters.AddWithValue("@model", selectedModel);
                            cmd.Parameters.AddWithValue("@plate", txtPlate.Text);
                            cmd.Parameters.AddWithValue("@mileage", string.IsNullOrEmpty(txtMileage.Text) ? 0 : Convert.ToInt32(txtMileage.Text));
                            cmd.Parameters.AddWithValue("@comment", txtVehicleComment.Text);
                            vehicleId = (long)cmd.ExecuteScalar();
                        }
                        string insertOrder = @"INSERT INTO WorkOrders (ClientId, VehicleId, IssueDescription, Status, AdditionalWorks, Materials, MainWork)
                            VALUES (@cId, @vId, @desc, @status, @add, @mat, @mainWork);";
                        using (var cmd = new SQLiteCommand(insertOrder, conn))
                        {
                            cmd.Parameters.AddWithValue("@cId", clientId);
                            cmd.Parameters.AddWithValue("@vId", vehicleId);
                            cmd.Parameters.AddWithValue("@desc", txtIssue.Text);
                            cmd.Parameters.AddWithValue("@status", cmbOrderStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@add", txtAdditionalWorks.Text);
                            cmd.Parameters.AddWithValue("@mat", txtMaterials.Text);
                            cmd.Parameters.AddWithValue("@mainWork", cmbPriceWorks.SelectedItem?.ToString() ?? "");
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Заказ-наряд успешно сохранен!");
                        txtPlate.Clear(); txtMileage.Clear(); txtVehicleComment.Clear();
                        txtIssue.Clear(); txtAdditionalWorks.Clear(); txtMaterials.Clear();
                        RefreshOrdersHistoryGrid();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }
    }
}