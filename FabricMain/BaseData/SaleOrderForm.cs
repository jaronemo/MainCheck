using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using FabricBLL;
using FabricModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Reporting.Charting;

namespace FabricMain
{
    public partial class SaleOrderForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<SaleOrderUnit> salesOrders;
        private List<BussinessUnit> customers;
        private BindingList<ProductBasicInfoUnit> products;
        private List<int> allOrderIds = new List<int>();
        private int currentRecordIndex = -1;
        private int currentOrderIndex = 0;
        public SaleOrderForm()
        {
            InitializeComponent();
            this.KeyPreview = true;

           /* productCodes = GetAllProductCodes();
            productNames = GetAllProductNames();*/
        }
        private void btnClose_Click(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaleOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }
        private void SaleOrderForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadInspectionItems();
            LoadLabels();
            /*LoadSalesOrderData();
            LoadSalesOrderDetailData();*/
            // 初始化和填充salesOrders列表
            SaleOrderManage salesOrderManager = new SaleOrderManage();
            salesOrders = salesOrderManager.GetList();

            if (salesOrders != null && salesOrders.Count > 0)
            {
                LoadRecordByIndex(salesOrders.Count - 1); // 加載最後一筆資料
            }          
        }

        private Dictionary<string, int> customerDict = new Dictionary<string, int>();
        private void LoadCustomers()
        {
            // 使用BusinessUnitManager從數據庫中獲取客戶列表
            BussinessUnitManage customerBLL = new BussinessUnitManage();
            customers = customerBLL.GetList();

            foreach (BussinessUnit customer in customers)
            {
                cbCustomer.Properties.Items.Add(customer.Code);
                cbCustomer2.Properties.Items.Add(customer.Name);
                customerDict[customer.Code] = customer.No;
            }
        }
        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 確保comboBoxEdit1已經有選擇
            if (cbCustomer.SelectedIndex >= 0)
            {
                // 根據選擇的客戶代碼找到對應的客戶名稱
                string selectedCode = cbCustomer.Properties.Items[cbCustomer.SelectedIndex].ToString();
                var selectedCustomer = customers.FirstOrDefault(c => c.Code == selectedCode);
                if (selectedCustomer != null)
                {
                    // 將客戶名稱填充到comboBoxEdit2中
                    cbCustomer2.Text = selectedCustomer.Name;
                }
            }
        }
        private void cbCustomer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustomer2.SelectedIndex >= 0)
            {
                // 根據選擇的客戶名稱找到對應的客戶代碼
                string selectedName = cbCustomer2.Properties.Items[cbCustomer2.SelectedIndex].ToString();
                var selectedCustomer = customers.FirstOrDefault(c => c.Name == selectedName);
                if (selectedCustomer != null)
                {
                    // 將客戶代碼填充到comboBoxEdit1中
                    cbCustomer.Text = selectedCustomer.Code;
                }
            }
        }
        private void LoadInspectionItems()
        {
            // 使用DefectiveItemManage從數據庫中獲取檢驗項目列表
            DefectiveItemManage inspectionBLL = new DefectiveItemManage();
            List<DefectiveItemUnit> inspectionItems = inspectionBLL.GetList();

            foreach (DefectiveItemUnit item in inspectionItems)
            {
                cbInspectionItem.Properties.Items.Add(item.Name);
            }
        }
        private void LoadLabels()
        {
            // 使用PickingLabelManage從數據庫中獲取標籤列表
            PickingLabelManage labelBLL = new PickingLabelManage();
            List<PickingLabelUnit> labels = labelBLL.GetList();

            foreach (PickingLabelUnit label in labels)
            {
                cbLabel.Properties.Items.Add(label.Code);
            }
        }

        private void SetDisable()
        {
            txtOrderName.ReadOnly = true;
            cbCustomer.ReadOnly = true;
            cbCustomer2.ReadOnly = true;
            txtDeliveryTo.ReadOnly = true;            
            txtDeliveryLocation.ReadOnly = true;   
            txtOriginLocation.ReadOnly = true;            
            txtCustomerOrder.ReadOnly = true;            
            txtOrderBuyer.ReadOnly = true;            
            txtPoNumber.ReadOnly = true;
            dateOrderDate.ReadOnly = true;
            dateDeliveryDate.ReadOnly = true;
            cbInspectionItem.ReadOnly = true;   
            cbLabel.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;

        }
        private void PreviousRecord()
        {
            if (currentOrderIndex > 0)
            {
                currentOrderIndex--;
                LoadRecordByIndex(currentOrderIndex);
            }
            else
            {
                MessageBox.Show("已經是第一筆資料了！");
            }
        }

        private void NextRecord()
        {
            if (currentOrderIndex < salesOrders.Count - 1)
            {
                currentOrderIndex++;
                LoadRecordByIndex(currentOrderIndex);
            }
            else
            {
                MessageBox.Show("已經是最後一筆資料了！");
            }
        }


        private void LoadRecordByIndex(int index)
        {

            /*int orderId = allOrderIds[index];
            SaleOrderUnit order = salesOrders.FirstOrDefault(o => o.OrderId == orderId);*/

            if (index >= 0 && index < salesOrders.Count)
            {
                SaleOrderUnit order = salesOrders[index];
                // 使用order物件更新您的UI
                txtOrderID.Text = order.OrderId.ToString();
                txtOrderID.ReadOnly = true;
                txtOrderID.Visible = false;
                txtOrderName.Text = order.OrderName.ToString();
                txtOrderName.ReadOnly = true;
                // 顯示客戶資料
                string no = order.CustomerId.ToString();
                BussinessUnitManage customerBLL = new BussinessUnitManage();
                BussinessUnit customer = customerBLL.Get(no);
                cbCustomer.Text = customer.Code;
                cbCustomer2.Text = customer.Name;
                cbCustomer.ReadOnly = true;
                cbCustomer2.ReadOnly = true;
                // 顯示其他訂單資料
                txtDeliveryTo.Text = order.DeliveryTo;
                txtDeliveryTo.ReadOnly = true;
                txtDeliveryLocation.Text = order.DeliveryLocation;
                txtDeliveryLocation.ReadOnly = true;
                txtOriginLocation.Text = order.OriginLocation;
                txtOriginLocation.ReadOnly = true;
                txtCustomerOrder.Text = order.CustomerOrder;
                txtCustomerOrder.ReadOnly = true;
                txtOrderBuyer.Text = order.OrderBuyer;
                txtOrderBuyer.ReadOnly = true;
                txtPoNumber.Text = order.PoNumber;
                txtPoNumber.ReadOnly = true;

                // 顯示日期欄位
                dateOrderDate.EditValue = order.OrderDate;
                dateOrderDate.ReadOnly = true;
                dateDeliveryDate.EditValue = order.DeliveryDate;
                dateDeliveryDate.ReadOnly = true;

                // 顯示季節欄位
                txtSeason.Text = order.Season;
                txtSeason.ReadOnly = true;

                // 顯示檢驗項目和標籤
                if (order.Inspection_id.HasValue)
                {
                    int ins_id = order.Inspection_id.Value;
                    DefectiveItemManage inspectionBLL = new DefectiveItemManage();
                    DefectiveItemUnit inspection = inspectionBLL.Get(ins_id);
                    cbInspectionItem.Text = inspection.Name;
                }
                else
                {
                    cbInspectionItem.Text = "";
                }
                cbInspectionItem.ReadOnly = true;
                if (order.Label_id.HasValue)
                {
                    int label_id = order.Label_id.Value;
                    PickingLabelManage labelBLL = new PickingLabelManage();
                    PickingLabelUnit label = labelBLL.Get(label_id.ToString());
                    cbLabel.Text = label.Code;
                }
                else
                {
                    cbLabel.Text = "";
                }
                cbLabel.ReadOnly = true;
                int currentOrderId = order.OrderId;
                LoadSalesOrderDetailData(currentOrderId); // 重新加載明細資料
                currentOrderIndex = index; // 更新當前索引
            }
        }

        private void LoadSalesOrderData()
        {

            // 使用SalesOrderManager 從數據庫中獲取所有銷售訂單資料
            SaleOrderManage salesOrderManager = new SaleOrderManage();
            salesOrders = salesOrderManager.GetList();
            allOrderIds = salesOrders.Select(o => o.OrderId).ToList();


            // 如果有銷售訂單資料，則將最後一筆訂單資料顯示在Label、TextBox或ComboBox中            
            if (salesOrders.Count > 0)
            {
                SaleOrderUnit lastSalesOrder = salesOrders[salesOrders.Count - 1];

                // 顯示訂單編號及隱藏欄位
                txtOrderID.Text = lastSalesOrder.OrderId.ToString();
                txtOrderID.Visible = false;
                txtOrderName.Text = lastSalesOrder.OrderName.ToString();
                txtOrderName.ReadOnly = true;

                // 顯示客戶資料
                string no = lastSalesOrder.CustomerId.ToString();
                BussinessUnitManage customerBLL = new BussinessUnitManage();
                BussinessUnit customer = customerBLL.Get(no);
                cbCustomer.Text = customer.Code;
                cbCustomer2.Text = customer.Name;
                cbCustomer.ReadOnly = true;
                cbCustomer2.ReadOnly = true;

                // 顯示其他訂單資料
                txtDeliveryTo.Text = lastSalesOrder.DeliveryTo;
                txtDeliveryTo.ReadOnly = true;
                txtDeliveryLocation.Text = lastSalesOrder.DeliveryLocation;
                txtDeliveryLocation.ReadOnly = true;
                txtOriginLocation.Text = lastSalesOrder.OriginLocation;
                txtOriginLocation.ReadOnly = true;
                txtCustomerOrder.Text = lastSalesOrder.CustomerOrder;
                txtCustomerOrder.ReadOnly = true;
                txtOrderBuyer.Text = lastSalesOrder.OrderBuyer;
                txtOrderBuyer.ReadOnly = true;
                txtPoNumber.Text = lastSalesOrder.PoNumber;
                txtPoNumber.ReadOnly = true;

                // 顯示日期欄位
                dateOrderDate.EditValue = lastSalesOrder.OrderDate;
                dateOrderDate.ReadOnly = true;
                dateDeliveryDate.EditValue = lastSalesOrder.DeliveryDate;
                dateDeliveryDate.ReadOnly = true;

                // 顯示季節欄位
                txtSeason.Text = lastSalesOrder.Season;
                txtSeason.ReadOnly = true;

                // 顯示檢驗項目和標籤
                if (lastSalesOrder.Inspection_id.HasValue)
                {
                    int ins_id = lastSalesOrder.Inspection_id.Value;
                    DefectiveItemManage inspectionBLL = new DefectiveItemManage();
                    DefectiveItemUnit inspection = inspectionBLL.Get(ins_id);
                    cbInspectionItem.Text = inspection.Name;
                }
                else
                {
                    cbInspectionItem.Text = "";
                }
                cbInspectionItem.ReadOnly = true;
                if (lastSalesOrder.Label_id.HasValue)
                {
                    int label_id = lastSalesOrder.Label_id.Value;
                    PickingLabelManage labelBLL = new PickingLabelManage();
                    PickingLabelUnit label = labelBLL.Get(label_id.ToString());
                    cbLabel.Text = label.Code;
                }
                else
                {
                    cbLabel.Text = "";
                }
                cbLabel.ReadOnly = true;
            }
            if (salesOrders.Count > 0)
            {
                SaleOrderUnit lastSalesOrder = salesOrders[salesOrders.Count - 1];
                currentRecordIndex = allOrderIds.IndexOf(lastSalesOrder.OrderId);
            }

        }

        private void GetAllProducts()
        {
            ProductBasicInfoManage productManage = new ProductBasicInfoManage();
            products = new BindingList<ProductBasicInfoUnit>(productManage.GetList());
        }

        private void LoadSalesOrderDetailData(int orderId)
        {
            GetAllProducts();
            // 清除 DataGridView 的数据源和行数据
            // 清除 DataGridView 的数据源和行数据
            gridControl1.DataSource = null;
            SaleOrderDetailManage OrderList = new SaleOrderDetailManage();
            List<SaleOrderDetailUnit> list = OrderList.GetListByOrderId(orderId); // 使用新的方法

            BindingList<SaleOrderDetailUnit> bindingList = new BindingList<SaleOrderDetailUnit>(list);
            gridControl1.DataSource = bindingList;
            gridView1.RefreshData();

            // 自定義列的顯示名稱
            Dictionary<string, string> columnCaptions = new Dictionary<string, string>
            {
                { "ProductID", "品名代碼" },
                { "Width", "幅寬" },
                { "Weight", "碼重" },
                { "GSM", "g/m2" },
                { "OrderQuantity", "訂單量" },
                { "InputQuantity", "來胚量" },
                { "FinishedQuantity", "成品量" },
                { "ShippedQuantity", "出貨量" },
                { "TransferQuantity", "轉單量" },
                { "ReturnedQuantity", "退胚量" },
                { "Inventory", "庫" },
                { "Grade", "等級判定" }
            };

            foreach (var column in columnCaptions)
            {
                if (gridView1.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView1.Columns[column.Key].Caption = column.Value;
                }
            }
            
            // 設置ProductID欄位為SearchLookUpEdit的形式
            var repositoryItemSearchLookUpEdit = new RepositoryItemSearchLookUpEdit();
            repositoryItemSearchLookUpEdit.DataSource = products;
            repositoryItemSearchLookUpEdit.PopulateViewColumns();
            repositoryItemSearchLookUpEdit.View.Columns["No"].Visible = false;
            repositoryItemSearchLookUpEdit.View.Columns["Cloth_id"].Visible = false;
            repositoryItemSearchLookUpEdit.View.Columns["Code"].Caption = "品名代碼";
            repositoryItemSearchLookUpEdit.View.Columns["Name"].Caption = "品名描述";
            repositoryItemSearchLookUpEdit.ValueMember = "No";
            repositoryItemSearchLookUpEdit.DisplayMember = "Code";            
            repositoryItemSearchLookUpEdit.PopupFilterMode = PopupFilterMode.Contains; // 設置搜索模式為包含模式

            gridView1.Columns["ProductID"].ColumnEdit = repositoryItemSearchLookUpEdit;


            // 檢查是否已經存在"品名描述"列
            if (!gridView1.Columns.Any(col => col.FieldName == "ProductName"))
            {
                // 設定 ProductName 列
                var colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
                colProductName.FieldName = "ProductName";
                colProductName.Caption = "品名描述";
                colProductName.UnboundType = DevExpress.Data.UnboundColumnType.String; // 設置為非綁定列
                colProductName.Visible = true;
                gridView1.Columns.Add(colProductName);

                var repositoryItemTextEdit = new RepositoryItemTextEdit();
                colProductName.ColumnEdit = repositoryItemTextEdit;
            }


            gridView1.Columns["NO"].Visible = false;
            gridView1.Columns["SaleOrderID"].Visible = false;
            gridView1.Columns["ProductID"].VisibleIndex = 0;
            gridView1.Columns["ProductName"].VisibleIndex = 1;
            gridView1.Columns["Width"].VisibleIndex = 2;
            gridView1.Columns["Weight"].VisibleIndex = 3;
            gridView1.Columns["GSM"].VisibleIndex = 4;
            gridView1.Columns["OrderQuantity"].VisibleIndex = 5;
            gridView1.Columns["InputQuantity"].VisibleIndex = 6;
            gridView1.Columns["FinishedQuantity"].VisibleIndex = 7;
            gridView1.Columns["ShippedQuantity"].VisibleIndex = 8;
            gridView1.Columns["TransferQuantity"].VisibleIndex = 9;
            gridView1.Columns["ReturnedQuantity"].VisibleIndex = 10;
            gridView1.Columns["Inventory"].VisibleIndex = 11;
            gridView1.Columns["Grade"].VisibleIndex = 12;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object productIDObj = gridView1.GetRowCellValue(i, "ProductID");
                if (productIDObj != null && int.TryParse(productIDObj.ToString(), out int productID))
                {
                    var selectedProduct = products.FirstOrDefault(p => p.No == productID);
                    if (selectedProduct != null)
                    {
                        gridView1.SetRowCellValue(i, "ProductName", selectedProduct.Name);
                    }
                }
            }
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
            bsiRecordsCount.Caption = "記錄 : " + bindingList.Count;
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "ProductName" && e.IsGetData)
            {
                int selectedId = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ProductID"));
                var selectedProduct = products.FirstOrDefault(p => p.No == selectedId);
                if (selectedProduct != null)
                {
                    e.Value = selectedProduct.Name;
                }
            }
        }
        private void ClearScreenData()
        {
            // 清除文本框的数据
            txtOrderID.Text = string.Empty;
            txtOrderName.Text = string.Empty;
            txtDeliveryTo.Text = string.Empty;
            txtDeliveryLocation.Text = string.Empty;
            txtOriginLocation.Text = string.Empty;
            txtCustomerOrder.Text = string.Empty;
            txtOrderBuyer.Text = string.Empty;
            txtPoNumber.Text = string.Empty;
            txtSeason.Text = string.Empty;
            dateOrderDate.EditValue = null;
            dateDeliveryDate.EditValue = null;

            // 清空客户字段
            cbCustomer.Text = string.Empty;
            cbCustomer2.Text = string.Empty;

            // 清空客户字段
            cbCustomer.EditValue = null;
            cbCustomer.Properties.Items.Clear();
            cbCustomer2.EditValue = null;
            cbCustomer2.Properties.Items.Clear();

            // 清空檢驗項目和標籤
            cbInspectionItem.Text = string.Empty;
            cbLabel.Text = string.Empty;

            // 将客户字段设置为必填项
            cbCustomer.Properties.Appearance.BackColor = Color.LightYellow;
            cbCustomer.Properties.AllowNullInput = DefaultBoolean.True;
            cbCustomer.Properties.NullValuePrompt = "請填客戶的代碼";
            cbCustomer2.Properties.Appearance.BackColor = Color.LightYellow;
            cbCustomer2.Properties.AllowNullInput = DefaultBoolean.True;
            cbCustomer2.Properties.NullValuePrompt = "請填寫客戶的名稱";

            // 清除GridControl中的数据
            gridControl1.DataSource = null;
            // 重新載入客戶資料
            LoadCustomers();

            // 去除ReadOnly屬性
            cbCustomer.ReadOnly = false;
            cbCustomer2.ReadOnly = false;
            txtDeliveryTo.ReadOnly = false;
            txtDeliveryLocation.ReadOnly = false;
            txtOriginLocation.ReadOnly = false;
            txtCustomerOrder.ReadOnly = false;
            txtOrderBuyer.ReadOnly = false;
            txtPoNumber.ReadOnly = false;
            txtSeason.ReadOnly = false;
            dateOrderDate.ReadOnly = false;
            dateDeliveryDate.ReadOnly = false;
            cbInspectionItem.ReadOnly = false;
            cbLabel.ReadOnly = false;
        }
        private void barDockingMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearScreenData();
            txtOrderName.ReadOnly = true;
            BindingList<SaleOrderDetailUnit> emptyList = new BindingList<SaleOrderDetailUnit>();
            gridControl1.DataSource = emptyList;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom; // 或 NewItemRowPosition.Bottom
            dateOrderDate.Focus();
        }

        private void SaleOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 模擬Tab鍵的行為
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                // 上一筆記錄
                PreviousRecord();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                // 下一筆記錄
                NextRecord();
                e.Handled = true;
            }
        }
        

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridView view = sender as GridView;
                if (view != null)
                {
                    int nextColumnHandle = view.FocusedColumn.VisibleIndex + 1;
                    if (nextColumnHandle < view.VisibleColumns.Count)
                    {
                        view.FocusedColumn = view.VisibleColumns[nextColumnHandle];
                    }
                    else
                    {
                        // Move to the first column of the next row
                        int nextRowHandle = view.FocusedRowHandle + 1;
                        if (nextRowHandle < view.RowCount)
                        {
                            view.FocusedRowHandle = nextRowHandle;
                            view.FocusedColumn = view.VisibleColumns[0];
                        }
                    }
                    e.Handled = true;
                }               
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "ProductID")
            {
                int selectedId = (int)e.Value;
                var selectedProduct = products.FirstOrDefault(p => p.No == selectedId);
                if (selectedProduct != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "ProductName", selectedProduct.Name);
                }
            }
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            bool isNew = string.IsNullOrEmpty(txtOrderID.Text);
            string selectedCustomerCode = cbCustomer.Text;
            string selectedInspectionName = cbInspectionItem.Text;
            string selectedLabelCode = cbLabel.Text;

            // 使用字典從客戶代碼獲取客戶ID
            int selectedCustomerId = customerDict[selectedCustomerCode];
            // 使用名稱或代碼查找相應的ID
            DefectiveItemManage inspectionBLL = new DefectiveItemManage();
            DefectiveItemUnit selectedInspection = inspectionBLL.GetList().FirstOrDefault(i => i.Name == selectedInspectionName);
            int? selectedInspectionId = selectedInspection?.Id;

            PickingLabelManage labelBLL = new PickingLabelManage();
            PickingLabelUnit selectedLabel = labelBLL.GetList().FirstOrDefault(l => l.Code == selectedLabelCode);
            int? selectedLabelId = selectedLabel?.Id;
            // 主單資料
            SaleOrderUnit saleOrder = new SaleOrderUnit
            {
                OrderId = isNew ? 0 : int.Parse(txtOrderID.Text),
                OrderName = txtOrderName.Text,
                CustomerId = selectedCustomerId, // 使用獲取的客戶ID
                DeliveryTo = txtDeliveryTo.Text,
                DeliveryLocation = txtDeliveryLocation.Text,
                OriginLocation = txtOriginLocation.Text,
                CustomerOrder = txtCustomerOrder.Text,
                OrderBuyer = txtOrderBuyer.Text,
                PoNumber = txtPoNumber.Text,
                OrderDate = (DateTime)dateOrderDate.EditValue,
                DeliveryDate = (DateTime)dateDeliveryDate.EditValue,
                Season = txtSeason.Text,
                Inspection_id = selectedInspectionId,
                Label_id = selectedLabelId,
            };
            SaleOrderManage orderManager = new SaleOrderManage();
            SaleOrderDetailManage detailManager = new SaleOrderDetailManage();
            int newOrderId;
            if (isNew)
            {
                string orderNumber = GenerateOrderNumber();
                saleOrder.OrderName = orderNumber;
                newOrderId = orderManager.Add(saleOrder); // 假設Add方法返回新單據的ID
            }
            else
            {
                orderManager.Update(saleOrder);
                newOrderId = saleOrder.OrderId;
            }

            // 明細資料
            List<SaleOrderDetailUnit> existingDetails = detailManager.GetListByOrderId(saleOrder.OrderId);
            // 根據GridView1的行數判斷是否有明細資料
            object productIdCellValue = gridView1.GetRowCellValue(0, "ProductID");
            bool hasDetailData = gridView1.RowCount > 0 && productIdCellValue != null && !string.IsNullOrEmpty(productIdCellValue.ToString());

            // 流程一：新建銷售訂單-> 主單資料輸入 但是未輸入明細資料
            if (isNew && !hasDetailData)
            {
                // 不需要進一步的操作，因為沒有明細資料
            }
            // 流程二：新建銷售訂單->主單資料輸入 明細資料也有輸入
            if (isNew && hasDetailData)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    detailManager.Add(
                        int.Parse(gridView1.GetRowCellValue(i, "ProductID").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "Width").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "Weight").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "GSM").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "OrderQuantity").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "InputQuantity").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "FinishedQuantity").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "ShippedQuantity").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "TransferQuantity").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "ReturnedQuantity").ToString()),
                        decimal.Parse(gridView1.GetRowCellValue(i, "Inventory").ToString()),
                        gridView1.GetRowCellValue(i, "Grade").ToString(),
                        saleOrder.OrderId
                    );
                }
            }
            // 流程三：修改銷售訂單-> 主單修改資料，但是明細資料未修改
            // 這個流程只需要更新主單資料，明細資料不需要進行操作，所以在上面已經處理了
            // 流程四：修改銷售訂單-> 主單資料修改，明細資料新增及現有明細資料修改或未修改
            if (!isNew && hasDetailData)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int no = int.Parse(gridView1.GetRowCellValue(i, "NO").ToString());
                    SaleOrderDetailUnit detail = existingDetails.FirstOrDefault(d => d.NO == no);

                    if (detail == null) // 新增的明細
                    {
                        detailManager.Add(
                            int.Parse(gridView1.GetRowCellValue(i, "ProductID").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "Width").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "Weight").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "GSM").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "OrderQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "InputQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "FinishedQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "ShippedQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "TransferQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "ReturnedQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "Inventory").ToString()),
                            gridView1.GetRowCellValue(i, "Grade").ToString(),
                            saleOrder.OrderId
                        );
                    }
                    else // 修改的明細
                    {
                        detailManager.ChangeInfo(
                            no,
                            int.Parse(gridView1.GetRowCellValue(i, "ProductID").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "Width").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "Weight").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "GSM").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "OrderQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "InputQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "FinishedQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "ShippedQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "TransferQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "ReturnedQuantity").ToString()),
                            decimal.Parse(gridView1.GetRowCellValue(i, "Inventory").ToString()),
                            gridView1.GetRowCellValue(i, "Grade").ToString(),
                            saleOrder.OrderId
                        );
                    }
                }
            }

            // 流程五：修改銷售訂單->主單資料未修改，明細資料刪除，新增新的明細資料或有明細資料被修改。
            if (!isNew)
            {
                foreach (var detail in existingDetails)
                {
                    if (!Enumerable.Range(0, gridView1.RowCount).Any(index => int.Parse(gridView1.GetRowCellValue(index, "NO").ToString()) == detail.NO))
                    {
                        detailManager.Delete(detail.NO);
                    }
                }
            }

            MessageBox.Show("保存成功！");
            SetDisable();
            // 重新加載單據列表
            salesOrders = orderManager.GetList();
            int indexcheck = salesOrders.FindIndex(so => so.OrderId == newOrderId);
            if (indexcheck != -1)
            {
                LoadRecordByIndex(indexcheck); // 加載新單據
            }

        }

        private void btnModify_Click(object sender, ItemClickEventArgs e)
        {
            // 允許編輯文本框和下拉列表            
            txtDeliveryTo.ReadOnly = false;
            txtDeliveryLocation.ReadOnly = false;
            txtOriginLocation.ReadOnly = false;
            txtCustomerOrder.ReadOnly = false;
            txtOrderBuyer.ReadOnly = false;
            txtPoNumber.ReadOnly = false;
            txtSeason.ReadOnly = false;
            dateOrderDate.ReadOnly = false;
            dateDeliveryDate.ReadOnly = false;
            cbInspectionItem.ReadOnly = false;
            cbLabel.ReadOnly = false;

            // 允許編輯gridView1的行
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
        }

        private void btnDelete_Click(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("確定要刪除此銷售訂單及其所有明細資料嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int orderId = int.Parse(txtOrderID.Text); // 從界面上獲取要刪除的訂單ID

                SaleOrderDetailManage detailManager = new SaleOrderDetailManage();
                SaleOrderManage orderManager = new SaleOrderManage();

                // 1. 刪除與該訂單相關的所有明細資料
                List<SaleOrderDetailUnit> existingDetails = detailManager.GetListByOrderId(orderId);
                foreach (var detail in existingDetails)
                {
                    detailManager.Delete(detail.NO);
                }

                // 2. 刪除主單資料
                orderManager.Delete(orderId);

                MessageBox.Show("銷售訂單及其所有明細資料已成功刪除！");
                // 3. 重新加載最後一筆資料
                salesOrders = orderManager.GetList();
                if (salesOrders != null && salesOrders.Count > 0)
                {
                    LoadRecordByIndex(salesOrders.Count - 1); // 加載最後一筆資料
                }
                else
                {
                    ClearScreenData();
                }
            }
        }

        private void btnPreviousRecord(object sender, ItemClickEventArgs e)
        {
            PreviousRecord();
        }

        private void btnNextRecord(object sender, ItemClickEventArgs e)
        {
            NextRecord();
        }
        // 訂單編號生成器
        private int serialNumber = 1;
        private string GenerateOrderNumber()
        {
            // 獲取目前的年份後二位
            string year = DateTime.Now.ToString("yy");

            // 获取当前日期的月份，如果月份小于10，则前面补0
            string month = DateTime.Now.ToString("MM");

            // 生成订单号
            string orderNumber = $"G{year}{month}{serialNumber:D4}";

            // 每次生成订单号后，将流水号加1，以保证每个订单号都是唯一的
            serialNumber++;

            return orderNumber;
        }
    }

}