var dataTable;

$(document).ready(function () {
    LoadDataTable();
});
function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "Url":"/Admin/Product/GetAll"
        },
        "columns": [
            {"data":"title","width":"15%"},
            {"data":"isbn","width":"15%"},
            {"data":"author","width":"15%"},
            {"data":"price","width":"15%"}
        ]
    });
}