$(document).ready(function () {
    var stringnip = $("#nips").val();
    $("#historyTable").DataTable({
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
                    columns: [1, 2, 3]
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
            "url": "https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=0&nik=" + stringnip,
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

    $("#approvedByManagerTable").DataTable({
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
            "url": "https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=1&nik=" + stringnip,
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
                            status = '<span class="badge badge-success badge-pill">' + 'Approved' + '</span>';
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

    $("#approvedTable").DataTable({
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
            "url": "https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=2&nik=" + stringnip,
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

    $("#rejectedTable").DataTable({
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
            "url": "https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=3&nik=" + stringnip,
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
                            status = '<span class="badge badge-success badge-pill">' + 'Approved' + '</span>';
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

/*function exportToExcel() {
    var table = $('#historyTable').DataTable();
    table.buttons('excel:name').trigger();
}

function exportToPdf() {
    var table = $('#historyTable').DataTable();
    table.buttons('pdf:name').trigger();
}

function exportToExcel() {
    var table = $('#approvedByManagerTable').DataTable();
    table.buttons('excel:name').trigger();
}

function exportToPdf() {
    var table = $('#approvedByManagerTable').DataTable();
    table.buttons('pdf:name').trigger();
}

function exportToExcel() {
    var table = $('#approvedTable').DataTable();
    table.buttons('excel:name').trigger();
}

function exportToPdf() {
    var table = $('#approvedTable').DataTable();
    table.buttons('pdf:name').trigger();
}

function exportToExcel() {
    var table = $('#rejectedTable').DataTable();
    table.buttons('excel:name').trigger();
}

function exportToPdf() {
    var table = $('#rejectedTable').DataTable();
    table.buttons('pdf:name').trigger();
}*/

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

document.getElementById("btnPrint").onclick = function () {
    printElement(document.getElementById("formDetail"));
};

function printElement(elem) {
    var domClone = elem.cloneNode(true);

    var $printSection = document.getElementById("printSection");

    if (!$printSection) {
        var $printSection = document.createElement("div");
        $printSection.id = "printSection";
        document.body.appendChild($printSection);
    }

    $printSection.innerHTML = "<h1><b>Overtime Request Report</b></h1>";
    $printSection.appendChild(domClone);
    window.print();
}