$(document).ready(function () {
    /*var stringnip = $("#nips").val();*/
    var urlPost = "";
    if ($("#role").val() == "Manager") {
        urlPost = "https://localhost:44314/API/Requests/GetAllRequestByStatAndManagerId?status=0&managerId=" + $("#managerId").val();
    } else if ($("#role").val() == "Finance Controller") {
        urlPost = "https://localhost:44314/API/Requests/GetAllRequestByStat?status=1";
    }
    console.log(urlPost);
    $("#requestTable").DataTable({
        /*filter: true,*/
        /*dom:Bfrtip,*/
        columnDefs: [
            {
                className: 'text-center',
                targets: '_all'
            }
        ],
        /*buttons: [
            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Overtime Request History',
                sheetName: 'Overtime Request History',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                fileName: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4]
                }
            },
            {
                extend: 'pdfHtml5',
                name: 'pdf',
                title: 'Overtime Request History',
                sheetName: 'Overtime Request History',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                fileName: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4]
                }
            }
        ],*/
        ajax: {
            "url": urlPost,
            "datatype": "json",
            "dataSrc": ""
        },
        columns: [
            {
                "data": null,
                "render": function (data, type, full, meta) {
                    return meta.row + 1;
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['requestDate'].substr(0, 10)
                }
            },
            {
                "data": "nik"
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return row['firstName'] + " " + row['lastName'];
                }
            },
            {
                "data": "task"
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var startTH = row['startTime'].substr(11, 2);
                    var startTM = row['startTime'].substr(14, 2);
                    var endTH = row['endTime'].substr(11, 2);
                    var endTM = row['endTime'].substr(14, 2);
                    var totalSecStart = (startTH * 3600) + (startTM * 60);
                    var totalSecEnd = (endTH * 3600) + (endTM * 60);
                    var diffHours = (totalSecEnd - totalSecStart) / 3600;
                    /*var timeDiff = (row['endTime']['totalSeconds'] - row['startTime']['totalSeconds'])/3600;*/
                    return (diffHours) + ' Hours';
                }
            },
            {
                "data": "status",
                "render": function (data, type, row, meta) {
                    status = '';
                    switch (data) {
                        case 0:
                            status = '<span class="badge badge-warning badge-pill">' + 'Pending' + '</span>';
                            break;
                        case 1:
                            status = '<span class="badge badge-secondary badge-pill">' + 'Approved by Manager' + '</span>';
                            break;
                        case 2:
                            status = '<span class="badge badge-success badge-pill">' + 'Approved by Finance Controller' + '</span>';
                            break;
                        case 3:
                            status = '<span class="badge badge-danger badge-pill">' + 'Rejected' + '</span>';
                    }
                    return status;
                    /*if (row['status'] == 0) {
                        return 'Pending'
                    } else if (row['status'] == 1) {
                        return 'Approved by Manager'
                    } else if (row['status'] == 2) {
                        return 'Approved by Finance Controller'
                    } else if (row['status'] == 3) {
                        return 'Rejected'
                    }*/
                }
            },
            {
                "data": "",
                "orderable": false,
                "render": function (data, type, row, meta) {
                    return `<td scope="row"><a class="btn btn-info btn-sm text-light" data-url="" onclick="getdatabyID('${row.requestId}')" data-toggle="modal" data-target="#detailModal" title="Detail"><i class="fa fa-info-circle"></i></a></td>`
                }
            }
        ]
    });
})

function getdatabyID(requestId) {
    console.log(requestId)
    $.ajax({
        url: "https://localhost:44314/API/Requests/GetRequestById/" + requestId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result[0]);
            console.log(result[0].requestId);
            var reqDate = result[0].requestDate.substr(0, 10);
            var sHours = result[0].startTime.substr(11, 2);
            var sMinutes = result[0].startTime.substr(14, 2);
            /*var sTime = sHours + ":" + sMinutes + sMinutes;*/
            var sTime = result[0].startTime.substr(11, 5);
            var eHours = result[0].endTime.substr(11, 2);
            var eMinutes = result[0].endTime.substr(14, 2);
            /*var eTime = eHours + ":" + eMinutes + eMinutes;*/
            var eTime = result[0].endTime.substr(11, 5);
            var tSecStart = (sHours * 3600) + (sMinutes * 60);
            var tSecEnd = (eHours * 3600) + (eMinutes * 60);
            var tHours = (tSecEnd - tSecStart) / 3600 + " Hours";
            $('#dataNIK').val(result[0].nik);
            $('#dataName').val(result[0].firstName + " " + result[0].lastName);
            $('#dataRequestId').val(result[0].requestId);
            $('#dataRequestDate').val(reqDate);
            $('#dataStartTime').val(sTime);
            $('#dataEndTime').val(eTime);
            $('#dataTask').val(result[0].task);
            $('#dataTotal').val(tHours);
            /*$('#dataStatus').val(result[0].approvalStatus);*/
            if (result[0].status === 0) {
                $('#dataStatus').val("Pending");
            } else if (result[0].status === 1) {
                $('#dataStatus').val("Approved by Manager");
            } else if (result[0].status === 2) {
                $('#dataStatus').val("Approved");
            } else if (result[0].status === 3) {
                $('#dataStatus').val("Rejected");
            }
            $('#dataCommission').val("Rp" + (new Intl.NumberFormat(['ban', 'id']).format(result[0].commission)));
            $('#detailModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            swal({
                title: "FAILED",
                text: "Data tidak ditemukan!",
                icon: "error"
            }).then(function () {
                window.location.reload();
            });
        }
    });
    return false;
}

document.getElementById("btnApprove").onclick = function () {
    var objectData = new Object();
    objectData.NIK = $("#dataNIK").val();
    objectData.Email = $("#email").val();
    objectData.RequestId = $("#dataRequestId").val();
    if ($("#role").val() == "Manager") {
        objectData.Status = 1;
    } else if ($("#role").val() == "Finance Controller") {
        objectData.Status = 2;
    }
    $.ajax({
        url: 'https://localhost:44314/API/Requests/Approval',
        type: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(objectData)
    }).done((result) => {
        $("#requestTable").DataTable().ajax.reload();
        Swal.fire({
            title: 'Berhasil!',
            text: 'Data Berhasil Di Approve!',
            icon: 'success',
            confirmButtonText: 'Ok'
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Approve',
            icon: 'error',
            confirmButtonText: 'Ok'
        }).then(function () {
            window.location.reload();
        });
    });
    console.log(objectData.Email);
};

document.getElementById("btnReject").onclick = function () {
    var objectData = new Object();
    objectData.NIK = $("#dataNIK").val();
    objectData.Status = 3;
    objectData.Email = $("#email").val();
    objectData.RequestId = $("#dataRequestId").val();
    $.ajax({
        url: 'https://localhost:44314/API/Requests/Approval',
        type: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(objectData)
    }).done((result) => {
        $("#requestTable").DataTable().ajax.reload();
        Swal.fire({
            title: 'Berhasil!',
            text: 'Data Berhasil Di Reject!',
            icon: 'Success',
            confirmButtonText: 'Ok'
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Reject',
            icon: 'Error',
            confirmButtonText: 'Ok'
        }).then(function () {
            window.location.reload();
        });
    });
};