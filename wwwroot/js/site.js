

$(document).ready(function () {
    $("#Employee").DataTable({
        "processing": true,
        "serverSide": false,
        "filter": true,
        "orderMulti": true,
        "ajax": {
            "url": "/Employees/Index",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": true
        }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "emp_id", "name": "emp_id", "autoWidth": true },
            { "data": "FirstName", "name": "FirstName", "autoWidth": true },
            { "data": "LastName", "name": "LastName", "autoWidth": true },
            { "data": "MiddleName", "name": "MiddleName", "autoWidth": true },
            { "data": "Address", "name": "Address", "autoWidth": true },
            { "data": "StartDate", "name": "StartDate", "autoWidth": true },
            { "data": "PosCode", "name": "PosCode", "autoWidth": true },
            { "data": "DepartCode", "name": "DepartCode", "autoWidth": true },
            { "data": "TeleNum1", "name": "TeleNum1", "autoWidth": true },
            { "data": "TeleNum2", "name": "TeleNum2", "autoWidth": true },
            { "data": "CelNum1", "name": "CelNum1", "autoWidth": true },
            { "data": "CelNum2", "name": "CelNum2", "autoWidth": true },
            { "data": "Gender", "name": "Gender", "autoWidth": true },
            { "data": "Email", "name": "Email", "autoWidth": true },

            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>"; }
            },
        ]
    });
});
