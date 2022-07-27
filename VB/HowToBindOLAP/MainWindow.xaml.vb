Imports System.Windows
Imports DevExpress.Xpf.PivotGrid

Namespace HowToBindOLAP
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            pivotGridControl1.OlapConnectionString = "Provider=msolap;" & "Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" & "Initial Catalog=Adventure Works DW Standard Edition;" & "Cube Name=Adventure Works;"
            pivotGridControl1.BeginUpdate()
            ' Create Pivot Grid fields.
            Dim fieldMeasuresInternetSalesAmount As New PivotGridField()
            fieldMeasuresInternetSalesAmount.Caption = "Internet Sales Amount"
            fieldMeasuresInternetSalesAmount.Area = FieldArea.DataArea
            pivotGridControl1.Fields.Add(fieldMeasuresInternetSalesAmount)

            Dim fieldSales As New PivotGridField()
            fieldSales.Caption = "Cleared Amount"
            fieldSales.Area = FieldArea.DataArea
            fieldSales.CellFormat = "c"
            pivotGridControl1.Fields.Add(fieldSales)

            ' Populate fields with data.
            fieldMeasuresInternetSalesAmount.DataBinding = New DataSourceColumnBinding("[Measures].[Internet Sales Amount]")

            fieldSales.DataBinding = New OlapExpressionBinding("[Measures].[Internet Sales Amount] * 0.87")

            AddField("Country", FieldArea.RowArea, "[Customer].[Country].[Country]", 0)
            AddField("Fiscal Year", FieldArea.ColumnArea, "[Date].[Fiscal Year].[Fiscal Year]", 0)

            pivotGridControl1.EndUpdate()
        End Sub
        Private Function AddField(ByVal caption As String, ByVal area As FieldArea, ByVal fieldName As String, ByVal index As Integer) As PivotGridField
            Dim field As PivotGridField = pivotGridControl1.Fields.Add()
            field.Caption = caption
            field.Area = area
            If fieldName <> String.Empty Then
                field.DataBinding = New DataSourceColumnBinding(fieldName)
            End If
            field.AreaIndex = index
            Return field
        End Function
    End Class
End Namespace
