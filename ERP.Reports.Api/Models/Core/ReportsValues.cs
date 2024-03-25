namespace ERP.Reports.Api.Models.Core
{
    public class ReportsValues
    {
        public const string PreReception = "WM.PreReception";
        public const string PreReceptionPackageLabels = "WM.PreReceptionPackageLabels";
        public const string Receive = "WM.Receive";
        public const string ReplenishmentList = "WM.ReplenishmentList";
        public const string PurchaseOrder = "AP.PurchaseOrder";
        public const string Transfer = "IN.Transfer";
        public const string Quote = "AR.Quote";
        public const string SalesOrder = "AR.SalesOrder";
        public const string SalesOrderRequest = "AR.SalesOrderRequest";
        public const string Picking = "AR.PickingList";
        public const string Packing = "AR.PackingList";
        public const string CycleCount = "WM.CycleCountSheet";
        public const string CycleCountEntry = "WM.CycleCountDayLineBundleSheet";
        public const string CycleCountEntryManager = "WM.CycleCountDayLineBundleManagerSheet";
        public const string CycleCountSchedule = "WM.CycleCountScheduleSheet";
        public const string CycleCountDayDiscrepancy = "WM.CycleCountDayDiscrepancy";
        public const string PhysicalCountSheet = "WM.PhysicalCountSheet";
        public const string PackingListLabels = "WM.PackingLabel";
        public const string ShippingOrderTracking = "WM.ShippingOrderTracking";
        public const string ShippingOrderPackages = "AR.ShippingOrderPackages";
        public const string Invoice = "AR.Invoice";
        public const string IncomingShipments = "WM.IncomingShipments";
        public const string ReceivePackageLabel = "WM.ReceivePackageLabel";
        public const string QuickPicking = "WM.QuickPicking";
        public const string StagingTicket = "WM.StagingTicket";
        public const string QuickPacking = "WM.QuickPacking";
        public const string CommercialInvoice = "WM.CommercialInvoice";
        public const string QuickPackingLabel = "WM.QuickPackingLabel";
        public const string QuickPackageContentLabel = "WM.QuickPackageContentLabel";
        public const string QuickMachining = "WM.QuickMachining";
        public const string MTR = "WM.MTR";
        public const string CheckPrinting = "AP.CheckPrinting";
        public const string CheckPrintingWhitePaper = "AP.CheckPrintingWhitePaper";
        public const string RequestForQuotation = "AP.RequestForQuotation";
        public const string SalesStockAnalysis = "AP.SalesStockAnalysis";

        public const string QuickManufacturing = "WM.QuickManufacturing";
        public const string QuickManufacturingOutsourcing = "WM.QuickManufacturingOutsourcing";
        public const string QuickOutsourcing = "WM.QuickMachiningOut";

        public const string TrialBalance = "GL.TrialBalance";
        public const string GLDetailByAccount = "GL.GLDetailByAccount";
        public const string ManualJournalEntryDetail = "GL.ManualJournalEntryDetail";

        public const string InvoiceMatchingSalesOrder = "AR.InvoiceMatchingSalesOrder";
        public const string PurchaseOrderByStateAndType = "AP.PurchaseOrderByStateAndType";

        public const string SalesOrderByStateAndSalesperson = "AR.SalesOrderByStateAndSalesperson";
        public const string PurchaseOrderLifeCycle = "AP.PurchaseOrderLifeCycle";

        public const string VoucherByStatusAndDate = "AP.VoucherByStatusAndDate";

        public const string CustomerStatementAging = "AR.CustomerStatementAging";
        public const string CustomerTransactionsBalance = "AR.CustomerTransactionsBalance";

        public const string VendorStatementAging = "AP.VendorStatementAging";
        public const string VendorTransactionsBalance = "AP.VendorTransactionsBalance";
        public const string APVendorAging = "AP.VendorAging";
        public const string ARCustomerAging = "AR.CustomerAging";

        public const string APCheckRegister = "AP.CheckRegister";
        public const string AP1099Misc = "AP.1099Misc";

        public const string StockTransferPacking = "WM.StockTransferPacking";
        public const string StockTransferPicking = "WM.StockTransferPicking";
        public const string StockTransferPackingLabel = "WM.StockTransferPackingLabel";
        public const string StockTransferCommercialInvoice = "WM.StockTransferCommercialInvoice";

        public const string Payment = "AP.Payment";
        public const string Voucher = "AP.Voucher";

        public const string PaymentBatch = "AP.PaymentBatch";

        public const string DebitMemo = "AP.DebitMemo";
        public const string CreditMemo = "AR.CreditMemo";
        public const string Collection = "AR.Collection";
        public const string CollectionAdjustment = "AR.CollectionAdjustment";
        public const string PaymentAdjustment = "AP.PaymentAdjustment";
        public const string CashDeposit = "CM.CashDeposit";
        public const string BankTransfer = "CM.BankTransfer";
        public const string BankManualTransaction = "CM.BankManualTransaction";
        public const string BankAccountReconciliation = "CM.BankAccountReconciliation";

        public const string StagingLocationState = "WM.StagingLocationState";
        public const string StagingTicketInspection = "WM.StagingTicketInspection";
        public const string PickingStagingTicket = "WM.PickingStagingTicket";
        public const string PickingStagingTicketByLocation = "WM.PickingStagingTicketGroupLocation";

        public const string ReturnToVendor = "AP.RTV";
        public const string RMA = "AR.RMA";
        public const string QuickMachiningCertificate = "WM.QuickMachiningCertificate";
        public const string QuickOutsourcingCertificate = "WM.QuickOutsourcingCertificate";
        public const string QuickOutsourcingPacking = "WM.QuickOutsourcingPacking";

        public const string PhysicalCountDiscrepancy = "WM.PhysicalCountDiscrepancy";

        public const string QuickPickingStockTransferRequest = "WM.QuickPickingStockTransferRequest";
        public const string QuickPackingStockTransfer = "WM.QuickPackingStockTransfer";
        public const string QuickPackingStockTransferLabel = "WM.QuickPackingStockTransferLabel";
        public const string QuickPickingStockTransfer = "WM.QuickPickingStockTransfer";
        public const string InventoryAdjustment = "WM.InventoryAdjustment";
        public const string InventoryCostAdjustment = "WM.InventoryCostAdjustment";
        public const string BundleInfo = "WM.BundleInfo";

        public const string ManualJournal = "GL.ManualJournal";
        public const string MDQuickPacking = "WM.MDQuickPacking";
        public const string MDCommercialInvoice = "WM.MDCommercialInvoice";



        public const string WorkOrder = "MFG.WorkOrder";

        public const string WorkOrderRequest = "MFG.WorkOrderRequest";

        public const string MfgPickingWorkOrder = "MFG.PickingWorkOrder";

        public const string CMIQuickPicking = "WM.CMIQuickPicking";
        public const string CMIQuickPacking = "WM.CMIQuickPacking";
        public const string CMIReceive = "WM.CMIReceive";

        public const string APWriteOff = "AP.APWriteOff";
        public const string ARWriteOff = "AR.ARWriteOff";

        public const string JobTraveler = "MFG.JobTraveler";

        public const string BillOfLading = "WM.BillOfLading";

        public const string MfgOperatorBadge = "MFG.OperatorBadge";

        public const string HeatSpecificationMTR = "SH.HeatSpecificationMTR";

        public const string BundleSpecificationMTR = "SH.BundleSpecificationMTR";

        public const string NCR = "QA.NCR";

        public const string NCRMiscellaneous = "QA.NCRMiscellaneous";

        public const string SalesOrderMaster = "AR.SalesOrderMaster";

        /*Customs Form Reports*/
        public const string SalesOrderMasterSeparate = "AR.SalesOrderMasterSeparate";

        public const string HeatSpecificationMTRTectubi = "SH.HeatSpecificationMTRTectubi";

        public const string BundleSpecificationMTRTectubi = "SH.BundleSpecificationMTRTectubi";

        public const string CertificateOfComplaiance = "WM.CertificateOfComplaiance";

        public const string HeatSpecificationMTREzeFlow = "SH.HeatSpecificationMTREzeFlow";

        public const string BundleSpecificationMTREzeFlow = "SH.BundleSpecificationMTREzeFlow";

        public const string PickingPipeTally = "WM.PickingPipeTally";
        public const string QuickPickingPalletWeightAndDims = "WM.QuickPickingPalletWeightandDims";

        public const string PickingPipeBundleTag = "WM.PickingPipeBundleTag";

        public const string QuickPackingTruckLoad = "WM.QuickPackingTruckLoad";

        public const string QuickPickingTruckPallets = "WM.QuickPickingTruckPallets";


        public const string PickingStockTransferPipeTally = "WM.PickingStockTransferPipeTally";

        public const string PickingStockTransferPipeBundleTag = "WM.PickingStockTransferPipeBundleTag";

        public const string CustomerStatementEmail = "AR.CustomerStatementEmail";
        public const string ShipmentPackageLabel = "WM.ShipmentPackageLabel";
    }
}