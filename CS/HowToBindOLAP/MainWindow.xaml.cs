using DevExpress.Xpf.PivotGrid;
using System.Windows;

namespace HowToBindOLAP {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            pivotGridControl1.OlapConnectionString = "Provider=msolap;" +
                "Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" +
                "Initial Catalog=Adventure Works DW Standard Edition;" +
                "Cube Name=Adventure Works;";
            pivotGridControl1.BeginUpdate();

            // Create Pivot Grid fields.
            PivotGridField fieldMeasuresInternetSalesAmount =
                new PivotGridField();
            fieldMeasuresInternetSalesAmount.Caption = "Internet Sales Amount";
            fieldMeasuresInternetSalesAmount.Area = FieldArea.DataArea;
            pivotGridControl1.Fields.Add(fieldMeasuresInternetSalesAmount);

            PivotGridField fieldSales = new PivotGridField();
            fieldSales.Caption = "Cleared Amount";
            fieldSales.Area = FieldArea.DataArea;
            fieldSales.CellFormat = "c";
            pivotGridControl1.Fields.Add(fieldSales);

            // Populate fields with data.
            fieldMeasuresInternetSalesAmount.DataBinding =
                new DataSourceColumnBinding("[Measures].[Internet Sales Amount]");

            fieldSales.DataBinding =
                new OlapExpressionBinding("[Measures].[Internet Sales Amount] * 0.87");

            AddField("Country", FieldArea.RowArea, "[Customer].[Country].[Country]", 0);
            AddField("Fiscal Year", FieldArea.ColumnArea, "[Date].[Fiscal Year].[Fiscal Year]", 0);

            pivotGridControl1.EndUpdate();
        }
        // Add fields to the Pivot Grid and bind them to data.
        private PivotGridField AddField(string caption, FieldArea area, string fieldName, int index) {
            PivotGridField field = pivotGridControl1.Fields.Add();
            field.Caption = caption;
            field.Area = area;
            if (fieldName != string.Empty)
                field.DataBinding = new DataSourceColumnBinding(fieldName);
            field.AreaIndex = index;
            return field;
        }
    }
}

