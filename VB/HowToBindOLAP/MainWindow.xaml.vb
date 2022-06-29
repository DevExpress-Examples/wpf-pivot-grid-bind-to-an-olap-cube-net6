Imports System.Windows
Imports DevExpress.Xpf.PivotGrid

Namespace HowToBindOLAP
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            pivotGridControl1.OlapConnectionString = "Provider=msolap;" & "Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" & "Initial Catalog=Adventure Works DW Standard Edition;" & "Cube Name=Adventure Works;"
            pivotGridControl1.BeginUpdate()
            ' Create fields.
            Dim fieldMeasuresInternetSalesAmount As PivotGridField = New PivotGridField()
            fieldMeasuresInternetSalesAmount.Caption = "Internet Sales Amount"
            fieldMeasuresInternetSalesAmount.Area = FieldArea.DataArea
            Dim fieldCustomerCountryCountry As PivotGridField = New PivotGridField()
            fieldCustomerCountryCountry.Caption = "Country"
            fieldCustomerCountryCountry.Area = FieldArea.RowArea
            Dim fieldDateFiscalYearFiscalYear As PivotGridField = New PivotGridField()
            fieldDateFiscalYearFiscalYear.Caption = "Fiscal Year"
            fieldDateFiscalYearFiscalYear.Area = FieldArea.ColumnArea
            Dim fieldSales As PivotGridField = New PivotGridField()
            fieldSales.Caption = "Cleared Amount"
            fieldSales.Area = FieldArea.DataArea
            fieldSales.CellFormat = "c"
            ' Populate fields with data.
            fieldMeasuresInternetSalesAmount.DataBinding = New DataSourceColumnBinding("[Measures].[Internet Sales Amount]")
            fieldCustomerCountryCountry.DataBinding = New DataSourceColumnBinding("[Customer].[Country].[Country]")
            fieldDateFiscalYearFiscalYear.DataBinding = New DataSourceColumnBinding("[Date].[Fiscal Year].[Fiscal Year]")
            fieldSales.DataBinding = New OlapExpressionBinding("[Measures].[Internet Sales Amount] * 0.87")
            ' Add fields to the PivotGridControl.
            pivotGridControl1.Fields.AddRange(fieldMeasuresInternetSalesAmount, fieldCustomerCountryCountry, fieldDateFiscalYearFiscalYear, fieldSales)
            pivotGridControl1.EndUpdate()
        End Sub
    End Class
End Namespace
