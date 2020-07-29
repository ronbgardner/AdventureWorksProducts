var dataTableProductDetail;
var dataTableCostHistory;

$(document).ready(function () {
    console.log('Product Detail ID: ' + productDetailID);

    loadDetailDataTable(productDetailID);
    loadCostHistoryDataTable(productDetailID);
});

function loadDetailDataTable(id) {

    dataTableProductDetail = $('#tblProductDetail').DataTable({
        "ajax": {
            "url": "/Product/GetProduct/" + id,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Key", "width": "50%" },
            { "data": "Value", "width": "50%" },
         ],
        "language": {
            "emptyTable": "No detail data found."
        },
        "width": "100%",
        "ordering": false,
        "paging": false,
        "searching": false,
        "info": false
    });
}


function loadCostHistoryDataTable(id) {

    dataTableCostHistory = $('#tblCostHistory').DataTable({
        "ajax": {
            "url": "/Product/ProductCostHistories/" + id,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "startDate", "width": "30%" },
            { "data": "endDate", "width": "30%" },
            {
                "data": "standardCost", "width": "15%",
                "render": $.fn.dataTable.render.number(',', '.', 2, '$')
            }
        ],
        "language": {
            "emptyTable": "No product cost available."
        },
        "width": "100%",
        "paging": false,
        "searching": false,
        "info": false
    });
}
