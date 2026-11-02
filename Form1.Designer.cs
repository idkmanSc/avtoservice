namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.txtClientComment = new System.Windows.Forms.TextBox();
            this.txtClientPhone = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientComment = new System.Windows.Forms.Label();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.cmbPriceWorks = new System.Windows.Forms.ComboBox();
            this.lblPriceWorks = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.txtMaterials = new System.Windows.Forms.TextBox();
            this.lblMaterials = new System.Windows.Forms.Label();
            this.txtAdditionalWorks = new System.Windows.Forms.TextBox();
            this.lblAdditionalWorks = new System.Windows.Forms.Label();
            this.txtIssue = new System.Windows.Forms.TextBox();
            this.lblIssue = new System.Windows.Forms.Label();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.grpVehicle = new System.Windows.Forms.GroupBox();
            this.txtVehicleComment = new System.Windows.Forms.TextBox();
            this.lblVehicleComment = new System.Windows.Forms.Label();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.lblMileage = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.tabPriceList = new System.Windows.Forms.TabPage();
            this.pnlPriceEdit = new System.Windows.Forms.Panel();
            this.btnDeletePrice = new System.Windows.Forms.Button();
            this.btnEditPrice = new System.Windows.Forms.Button();
            this.btnAddPrice = new System.Windows.Forms.Button();
            this.txtPriceValue = new System.Windows.Forms.TextBox();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.txtPriceWorkName = new System.Windows.Forms.TextBox();
            this.lblPriceWorkName = new System.Windows.Forms.Label();
            this.txtPriceCategory = new System.Windows.Forms.TextBox();
            this.lblPriceCategory = new System.Windows.Forms.Label();
            this.cmbPriceVehicleType = new System.Windows.Forms.ComboBox();
            this.lblPriceVehicleType = new System.Windows.Forms.Label();
            this.dgvPriceList = new System.Windows.Forms.DataGridView();
            this.tabOrdersHistory = new System.Windows.Forms.TabPage();
            this.dgvOrdersHistory = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.tabOrders.SuspendLayout();
            this.grpVehicle.SuspendLayout();
            this.tabPriceList.SuspendLayout();
            this.pnlPriceEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            this.tabOrdersHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClients);
            this.tabControl1.Controls.Add(this.tabOrders);
            this.tabControl1.Controls.Add(this.tabPriceList);
            this.tabControl1.Controls.Add(this.tabOrdersHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.btnDeleteClient);
            this.tabClients.Controls.Add(this.btnEditClient);
            this.tabClients.Controls.Add(this.dgvClients);
            this.tabClients.Controls.Add(this.btnAddClient);
            this.tabClients.Controls.Add(this.txtClientComment);
            this.tabClients.Controls.Add(this.txtClientPhone);
            this.tabClients.Controls.Add(this.txtClientName);
            this.tabClients.Controls.Add(this.lblClientComment);
            this.tabClients.Controls.Add(this.lblClientPhone);
            this.tabClients.Controls.Add(this.lblClientName);
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(876, 535);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Клиенты";
            this.tabClients.UseVisualStyleBackColor = true;
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Location = new System.Drawing.Point(694, 90);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(160, 30);
            this.btnDeleteClient.TabIndex = 9;
            this.btnDeleteClient.Text = "Удалить выбранного";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(694, 55);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(160, 30);
            this.btnEditClient.TabIndex = 8;
            this.btnEditClient.Text = "Сохранить изменения";
            this.btnEditClient.UseVisualStyleBackColor = true;
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(23, 140);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(831, 372);
            this.dgvClients.TabIndex = 7;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(694, 20);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(160, 30);
            this.btnAddClient.TabIndex = 6;
            this.btnAddClient.Text = "Добавить клиента";
            this.btnAddClient.UseVisualStyleBackColor = true;
            // 
            // txtClientComment
            // 
            this.txtClientComment.Location = new System.Drawing.Point(120, 90);
            this.txtClientComment.Name = "txtClientComment";
            this.txtClientComment.Size = new System.Drawing.Size(540, 20);
            this.txtClientComment.TabIndex = 5;
            // 
            // txtClientPhone
            // 
            this.txtClientPhone.Location = new System.Drawing.Point(120, 55);
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.Size = new System.Drawing.Size(200, 20);
            this.txtClientPhone.TabIndex = 3;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(120, 20);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(540, 20);
            this.txtClientName.TabIndex = 1;
            // 
            // lblClientComment
            // 
            this.lblClientComment.AutoSize = true;
            this.lblClientComment.Location = new System.Drawing.Point(20, 93);
            this.lblClientComment.Name = "lblClientComment";
            this.lblClientComment.Size = new System.Drawing.Size(80, 13);
            this.lblClientComment.TabIndex = 4;
            this.lblClientComment.Text = "Комментарий:";
            // 
            // lblClientPhone
            // 
            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Location = new System.Drawing.Point(20, 58);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.Size = new System.Drawing.Size(55, 13);
            this.lblClientPhone.TabIndex = 2;
            this.lblClientPhone.Text = "Телефон:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(20, 23);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(37, 13);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "ФИО:";
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.cmbPriceWorks);
            this.tabOrders.Controls.Add(this.lblPriceWorks);
            this.tabOrders.Controls.Add(this.btnCreateOrder);
            this.tabOrders.Controls.Add(this.txtMaterials);
            this.tabOrders.Controls.Add(this.lblMaterials);
            this.tabOrders.Controls.Add(this.txtAdditionalWorks);
            this.tabOrders.Controls.Add(this.lblAdditionalWorks);
            this.tabOrders.Controls.Add(this.txtIssue);
            this.tabOrders.Controls.Add(this.lblIssue);
            this.tabOrders.Controls.Add(this.cmbOrderStatus);
            this.tabOrders.Controls.Add(this.lblOrderStatus);
            this.tabOrders.Controls.Add(this.grpVehicle);
            this.tabOrders.Location = new System.Drawing.Point(4, 22);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(876, 535);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "Новый Заказ-наряд";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // cmbPriceWorks
            // 
            this.cmbPriceWorks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriceWorks.FormattingEnabled = true;
            this.cmbPriceWorks.Location = new System.Drawing.Point(542, 38);
            this.cmbPriceWorks.Name = "cmbPriceWorks";
            this.cmbPriceWorks.Size = new System.Drawing.Size(310, 21);
            this.cmbPriceWorks.TabIndex = 11;
            // 
            // lblPriceWorks
            // 
            this.lblPriceWorks.AutoSize = true;
            this.lblPriceWorks.Location = new System.Drawing.Point(539, 22);
            this.lblPriceWorks.Name = "lblPriceWorks";
            this.lblPriceWorks.Size = new System.Drawing.Size(183, 13);
            this.lblPriceWorks.TabIndex = 10;
            this.lblPriceWorks.Text = "Выбрать работу из прайс-листа:";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateOrder.Location = new System.Drawing.Point(542, 459);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(310, 45);
            this.btnCreateOrder.TabIndex = 9;
            this.btnCreateOrder.Text = "Создать заказ-наряд";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            // 
            // txtMaterials
            // 
            this.txtMaterials.Location = new System.Drawing.Point(542, 345);
            this.txtMaterials.Multiline = true;
            this.txtMaterials.Name = "txtMaterials";
            this.txtMaterials.Size = new System.Drawing.Size(310, 85);
            this.txtMaterials.TabIndex = 8;
            // 
            // lblMaterials
            // 
            this.lblMaterials.AutoSize = true;
            this.lblMaterials.Location = new System.Drawing.Point(539, 329);
            this.lblMaterials.Name = "lblMaterials";
            this.lblMaterials.Size = new System.Drawing.Size(149, 13);
            this.lblMaterials.TabIndex = 7;
            this.lblMaterials.Text = "Использованные материалы:";
            // 
            // txtAdditionalWorks
            // 
            this.txtAdditionalWorks.Location = new System.Drawing.Point(542, 230);
            this.txtAdditionalWorks.Multiline = true;
            this.txtAdditionalWorks.Name = "txtAdditionalWorks";
            this.txtAdditionalWorks.Size = new System.Drawing.Size(310, 85);
            this.txtAdditionalWorks.TabIndex = 6;
            // 
            // lblAdditionalWorks
            // 
            this.lblAdditionalWorks.AutoSize = true;
            this.lblAdditionalWorks.Location = new System.Drawing.Point(539, 214);
            this.lblAdditionalWorks.Name = "lblAdditionalWorks";
            this.lblAdditionalWorks.Size = new System.Drawing.Size(123, 13);
            this.lblAdditionalWorks.TabIndex = 5;
            this.lblAdditionalWorks.Text = "Дополнительные работы:";
            // 
            // txtIssue
            // 
            this.txtIssue.Location = new System.Drawing.Point(542, 95);
            this.txtIssue.Multiline = true;
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(310, 100);
            this.txtIssue.TabIndex = 4;
            // 
            // lblIssue
            // 
            this.lblIssue.AutoSize = true;
            this.lblIssue.Location = new System.Drawing.Point(539, 79);
            this.lblIssue.Name = "lblIssue";
            this.lblIssue.Size = new System.Drawing.Size(132, 13);
            this.lblIssue.TabIndex = 3;
            this.lblIssue.Text = "Описание неисправности:";
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(123, 22);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbOrderStatus.TabIndex = 1;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(23, 25);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(83, 13);
            this.lblOrderStatus.TabIndex = 0;
            this.lblOrderStatus.Text = "Статус заказа:";
            // 
            // grpVehicle
            // 
            this.grpVehicle.Controls.Add(this.txtVehicleComment);
            this.grpVehicle.Controls.Add(this.lblVehicleComment);
            this.grpVehicle.Controls.Add(this.txtMileage);
            this.grpVehicle.Controls.Add(this.lblMileage);
            this.grpVehicle.Controls.Add(this.txtPlate);
            this.grpVehicle.Controls.Add(this.lblPlate);
            this.grpVehicle.Controls.Add(this.cmbModel);
            this.grpVehicle.Controls.Add(this.lblModel);
            this.grpVehicle.Controls.Add(this.cmbBrand);
            this.grpVehicle.Controls.Add(this.lblBrand);
            this.grpVehicle.Controls.Add(this.cmbVehicleType);
            this.grpVehicle.Controls.Add(this.lblVehicleType);
            this.grpVehicle.Location = new System.Drawing.Point(20, 68);
            this.grpVehicle.Name = "grpVehicle";
            this.grpVehicle.Size = new System.Drawing.Size(480, 436);
            this.grpVehicle.TabIndex = 2;
            this.grpVehicle.TabStop = false;
            this.grpVehicle.Text = "Транспортное средство";
            // 
            // txtVehicleComment
            // 
            this.txtVehicleComment.Location = new System.Drawing.Point(120, 253);
            this.txtVehicleComment.Multiline = true;
            this.txtVehicleComment.Name = "txtVehicleComment";
            this.txtVehicleComment.Size = new System.Drawing.Size(330, 110);
            this.txtVehicleComment.TabIndex = 11;
            // 
            // lblVehicleComment
            // 
            this.lblVehicleComment.AutoSize = true;
            this.lblVehicleComment.Location = new System.Drawing.Point(20, 256);
            this.lblVehicleComment.Name = "lblVehicleComment";
            this.lblVehicleComment.Size = new System.Drawing.Size(80, 13);
            this.lblVehicleComment.TabIndex = 10;
            this.lblVehicleComment.Text = "Комментарий:";
            // 
            // txtMileage
            // 
            this.txtMileage.Location = new System.Drawing.Point(120, 208);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(200, 20);
            this.txtMileage.TabIndex = 9;
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(20, 211);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(47, 13);
            this.lblMileage.TabIndex = 8;
            this.lblMileage.Text = "Пробег:";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(120, 163);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(200, 20);
            this.txtPlate.TabIndex = 7;
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Location = new System.Drawing.Point(20, 166);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(66, 13);
            this.lblPlate.TabIndex = 6;
            this.lblPlate.Text = "Гос. номер:";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(120, 118);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(200, 21);
            this.cmbModel.TabIndex = 5;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(20, 121);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(49, 13);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Модель:";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(120, 73);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(200, 21);
            this.cmbBrand.TabIndex = 3;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(20, 76);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(43, 13);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Марка:";
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(120, 28);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(200, 21);
            this.cmbVehicleType.TabIndex = 1;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(20, 31);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(48, 13);
            this.lblVehicleType.TabIndex = 0;
            this.lblVehicleType.Text = "Тип ТС:";
            // 
            // tabPriceList
            // 
            this.tabPriceList.Controls.Add(this.dgvPriceList);
            this.tabPriceList.Controls.Add(this.pnlPriceEdit);
            this.tabPriceList.Location = new System.Drawing.Point(4, 22);
            this.tabPriceList.Name = "tabPriceList";
            this.tabPriceList.Size = new System.Drawing.Size(876, 535);
            this.tabPriceList.TabIndex = 2;
            this.tabPriceList.Text = "Прайс-лист";
            this.tabPriceList.UseVisualStyleBackColor = true;
            // 
            // pnlPriceEdit
            // 
            this.pnlPriceEdit.Controls.Add(this.btnDeletePrice);
            this.pnlPriceEdit.Controls.Add(this.btnEditPrice);
            this.pnlPriceEdit.Controls.Add(this.btnAddPrice);
            this.pnlPriceEdit.Controls.Add(this.txtPriceValue);
            this.pnlPriceEdit.Controls.Add(this.lblPriceValue);
            this.pnlPriceEdit.Controls.Add(this.txtPriceWorkName);
            this.pnlPriceEdit.Controls.Add(this.lblPriceWorkName);
            this.pnlPriceEdit.Controls.Add(this.txtPriceCategory);
            this.pnlPriceEdit.Controls.Add(this.lblPriceCategory);
            this.pnlPriceEdit.Controls.Add(this.cmbPriceVehicleType);
            this.pnlPriceEdit.Controls.Add(this.lblPriceVehicleType);
            this.pnlPriceEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPriceEdit.Location = new System.Drawing.Point(576, 0);
            this.pnlPriceEdit.Name = "pnlPriceEdit";
            this.pnlPriceEdit.Size = new System.Drawing.Size(300, 535);
            this.pnlPriceEdit.TabIndex = 1;
            // 
            // btnDeletePrice
            // 
            this.btnDeletePrice.Location = new System.Drawing.Point(23, 310);
            this.btnDeletePrice.Name = "btnDeletePrice";
            this.btnDeletePrice.Size = new System.Drawing.Size(255, 30);
            this.btnDeletePrice.TabIndex = 10;
            this.btnDeletePrice.Text = "Удалить услугу";
            this.btnDeletePrice.UseVisualStyleBackColor = true;
            // 
            // btnEditPrice
            // 
            this.btnEditPrice.Location = new System.Drawing.Point(23, 265);
            this.btnEditPrice.Name = "btnEditPrice";
            this.btnEditPrice.Size = new System.Drawing.Size(255, 30);
            this.btnEditPrice.TabIndex = 9;
            this.btnEditPrice.Text = "Сохранить изменения";
            this.btnEditPrice.UseVisualStyleBackColor = true;
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Location = new System.Drawing.Point(23, 220);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(255, 30);
            this.btnAddPrice.TabIndex = 8;
            this.btnAddPrice.Text = "Добавить услугу";
            this.btnAddPrice.UseVisualStyleBackColor = true;
            // 
            // txtPriceValue
            // 
            this.txtPriceValue.Location = new System.Drawing.Point(23, 175);
            this.txtPriceValue.Name = "txtPriceValue";
            this.txtPriceValue.Size = new System.Drawing.Size(255, 20);
            this.txtPriceValue.TabIndex = 7;
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Location = new System.Drawing.Point(20, 159);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(65, 13);
            this.lblPriceValue.TabIndex = 6;
            this.lblPriceValue.Text = "Цена (руб.):";
            // 
            // txtPriceWorkName
            // 
            this.txtPriceWorkName.Location = new System.Drawing.Point(23, 130);
            this.txtPriceWorkName.Name = "txtPriceWorkName";
            this.txtPriceWorkName.Size = new System.Drawing.Size(255, 20);
            this.txtPriceWorkName.TabIndex = 5;
            // 
            // lblPriceWorkName
            // 
            this.lblPriceWorkName.AutoSize = true;
            this.lblPriceWorkName.Location = new System.Drawing.Point(20, 114);
            this.lblPriceWorkName.Name = "lblPriceWorkName";
            this.lblPriceWorkName.Size = new System.Drawing.Size(118, 13);
            this.lblPriceWorkName.TabIndex = 4;
            this.lblPriceWorkName.Text = "Наименование работы:";
            // 
            // txtPriceCategory
            // 
            this.txtPriceCategory.Location = new System.Drawing.Point(23, 85);
            this.txtPriceCategory.Name = "txtPriceCategory";
            this.txtPriceCategory.Size = new System.Drawing.Size(255, 20);
            this.txtPriceCategory.TabIndex = 3;
            // 
            // lblPriceCategory
            // 
            this.lblPriceCategory.AutoSize = true;
            this.lblPriceCategory.Location = new System.Drawing.Point(20, 69);
            this.lblPriceCategory.Name = "lblPriceCategory";
            this.lblPriceCategory.Size = new System.Drawing.Size(63, 13);
            this.lblPriceCategory.TabIndex = 2;
            this.lblPriceCategory.Text = "Категория:";
            // 
            // cmbPriceVehicleType
            // 
            this.cmbPriceVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriceVehicleType.FormattingEnabled = true;
            this.cmbPriceVehicleType.Location = new System.Drawing.Point(23, 38);
            this.cmbPriceVehicleType.Name = "cmbPriceVehicleType";
            this.cmbPriceVehicleType.Size = new System.Drawing.Size(255, 21);
            this.cmbPriceVehicleType.TabIndex = 1;
            // 
            // lblPriceVehicleType
            // 
            this.lblPriceVehicleType.AutoSize = true;
            this.lblPriceVehicleType.Location = new System.Drawing.Point(20, 22);
            this.lblPriceVehicleType.Name = "lblPriceVehicleType";
            this.lblPriceVehicleType.Size = new System.Drawing.Size(48, 13);
            this.lblPriceVehicleType.TabIndex = 0;
            this.lblPriceVehicleType.Text = "Тип ТС:";
            // 
            // dgvPriceList
            // 
            this.dgvPriceList.AllowUserToAddRows = false;
            this.dgvPriceList.AllowUserToDeleteRows = false;
            this.dgvPriceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceList.Location = new System.Drawing.Point(0, 0);
            this.dgvPriceList.Name = "dgvPriceList";
            this.dgvPriceList.ReadOnly = true;
            this.dgvPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceList.Size = new System.Drawing.Size(570, 535);
            this.dgvPriceList.TabIndex = 0;
            // 
            // tabOrdersHistory
            // 
            this.tabOrdersHistory.Controls.Add(this.dgvOrdersHistory);
            this.tabOrdersHistory.Location = new System.Drawing.Point(4, 22);
            this.tabOrdersHistory.Name = "tabOrdersHistory";
            this.tabOrdersHistory.Size = new System.Drawing.Size(876, 535);
            this.tabOrdersHistory.TabIndex = 3;
            this.tabOrdersHistory.Text = "История заказов";
            this.tabOrdersHistory.UseVisualStyleBackColor = true;
            // 
            // dgvOrdersHistory
            // 
            this.dgvOrdersHistory.AllowUserToAddRows = false;
            this.dgvOrdersHistory.AllowUserToDeleteRows = false;
            this.dgvOrdersHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdersHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdersHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdersHistory.Name = "dgvOrdersHistory";
            this.dgvOrdersHistory.ReadOnly = true;
            this.dgvOrdersHistory.Size = new System.Drawing.Size(876, 535);
            this.dgvOrdersHistory.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мини CRM — Автосервис";
            this.tabControl1.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.tabClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.tabOrders.ResumeLayout(false);
            this.tabOrders.PerformLayout();
            this.grpVehicle.ResumeLayout(false);
            this.grpVehicle.PerformLayout();
            this.tabPriceList.ResumeLayout(false);
            this.pnlPriceEdit.ResumeLayout(false);
            this.pnlPriceEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
            this.tabOrdersHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersHistory)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientComment;
        private System.Windows.Forms.Label lblClientComment;
        private System.Windows.Forms.TextBox txtClientPhone;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.GroupBox grpVehicle;
        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtVehicleComment;
        private System.Windows.Forms.Label lblVehicleComment;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.TextBox txtIssue;
        private System.Windows.Forms.Label lblIssue;
        private System.Windows.Forms.TextBox txtAdditionalWorks;
        private System.Windows.Forms.Label lblAdditionalWorks;
        private System.Windows.Forms.TextBox txtMaterials;
        private System.Windows.Forms.Label lblMaterials;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.TabPage tabPriceList;
        private System.Windows.Forms.DataGridView dgvPriceList;
        private System.Windows.Forms.ComboBox cmbPriceWorks;
        private System.Windows.Forms.Label lblPriceWorks;
        private System.Windows.Forms.TabPage tabOrdersHistory;
        private System.Windows.Forms.DataGridView dgvOrdersHistory;
        private System.Windows.Forms.Panel pnlPriceEdit;
        private System.Windows.Forms.Button btnDeletePrice;
        private System.Windows.Forms.Button btnEditPrice;
        private System.Windows.Forms.Button btnAddPrice;
        private System.Windows.Forms.TextBox txtPriceValue;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.TextBox txtPriceWorkName;
        private System.Windows.Forms.Label lblPriceWorkName;
        private System.Windows.Forms.TextBox txtPriceCategory;
        private System.Windows.Forms.Label lblPriceCategory;
        private System.Windows.Forms.ComboBox cmbPriceVehicleType;
        private System.Windows.Forms.Label lblPriceVehicleType;
    }
}