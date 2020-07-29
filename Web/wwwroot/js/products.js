var dataTableProducts;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTableProducts = $('#tblData').DataTable({
        "ajax": {
            "url": "/Product/GetAllProducts/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "productId", "width": "20%" },
            { "data": "name", "width": "20%" },
            { "data": "productNumber", "width": "15%" },
            {
                "data": "listPrice", "width": "15%",
                "render": $.fn.dataTable.render.number(',', '.', 2, '$')
            },
            {
                "data": "productId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Product/ProductDetail/${data}" style='cursor:pointer; width:100px;'>view</a>                                
                            </div>
                            `;
                }, "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "No products found."
        },
        "width": "100%"
    });
}