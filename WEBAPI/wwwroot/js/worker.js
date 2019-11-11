var crudCarBrandBaseUrl = "https://localhost:44379/api/carbrands/";
var crudCarModelBaseUrl = "https://localhost:44379/api/carmodels/";
var crudCarPhotoBaseUrl = "https://localhost:44379/api/carphotos/";
var selcarBrandId = "";
var selCarModelId = "";
$("#maingrid").kendoGrid({
    dataSource: {
        transport: {
            read: {
                url: crudCarBrandBaseUrl,
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8"
            },
            update: {
                type: "PUT",
                url: function (data) {
                    return crudCarBrandBaseUrl + data.id;
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            destroy: {
                type: "DELETE",
                url: function (data) {
                    return crudCarBrandBaseUrl + data.id;
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            create: {
                type: "POST",
                url: crudCarBrandBaseUrl,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && operation !== "destroy" && options.models) {
                    carBrandId = data.id;
                    if (operation !== "create")
                        return kendo.stringify(options);

                    data.id = kendo.guid();
                    return options;
                }
                return kendo.data.transports["odata-v4"].parameterMap(options, operation);
            }
        },
        pageSize: 20,
        serverPaging: false,
        serverFiltering: false,
        serverSorting: false,
        schema: {
            model: {
                id: "id",
                fields: {
                    name: {
                        type: "string"
                    },
                    logo: {
                        type: "string"
                    },
                    describe: {
                        type: "string"
                    }
                }
            }
        }
    },
    selectable: "row",
    pageable: true,
    dataBound: function () {
        this.expandRow(this.tbody.find("tr.k-master-row").first());
    },
    height: 400,
    toolbar: ["create"],
    columns: [
        { field: "name", title: "Name", format: "{0:c}", width: "80px" },
        {
            template: "<div class='brand-logo'" +
                "style='background-image: url(#:data.logo#);'></div>",
            field: "logo",
            title: "Logo",
            width: "120px"
        },
        { field: "describe", title: "Describe", width: "80%" },
        { command: ["edit", "destroy", "test"], title: "&nbsp;", width: "250px" }
    ],
    editable: "popup"
});

$("#maingrid tbody").on("click", "tr", function (e) {
    var gview = $("#maingrid").data("kendoGrid");
    var selectedItem = gview.dataItem(gview.select());
    if (selectedItem == null)
        return;
    selcarBrandId = selectedItem.id;
    var sec = $("#secondgrid").data("kendoGrid");
    sec.dataSource.read();
    sec.dataSource.filter({
        field: "id",
        operator: "eq",
        value: selcarBrandId
    });
    sec.dataSource.query({
        filter: {
            field: "id",
            operator: "eq",
            value: selcarBrandId
        }, pageSize: 5, page: 1
    });
    sec.refresh();
    document.getElementById("selCarBrandId").innerText = selcarBrandId;
});

$("#secondgrid").kendoGrid({
    dataSource: {
        transport: {
            read: {
                url: crudCarModelBaseUrl,
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8"
            },
            update: {
                type: "PUT",
                url: function (data) {
                    return crudCarModelBaseUrl + data.id;
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            destroy: {
                type: "DELETE",
                url: function (data) {
                    return crudCarModelBaseUrl + data.id;
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            create: {
                type: "POST",
                url: crudCarModelBaseUrl,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && operation !== "destroy" && options.models) {
                    if (operation !== "create")
                        return kendo.stringify(options);

                    data.id = kendo.guid();
                    return options;
                }
                return kendo.data.transports["odata-v4"].parameterMap(options, operation);
            }
        },
        schema: {
            model: {
                id: "id",
                fields: {
                    name: {
                        type: "string"
                    },
                    photo: {
                        type: "string"
                    },
                    carBrandId: {
                        type: "string"
                    }
                }
            }
        },
        serverPaging: true,
        serverSorting: true,
        serverFiltering: true,
        pageSize: 5,
        filter: {
            field: "id",
            operator: "eq",
            value: selcarBrandId
        }
    },
    selectable: "row",
    scrollable: true,
    sortable: false,
    pageable: true,
    height: 400,
    toolbar: ["create"],
    columns: [
        { field: "name", title: "Name", format: "{0:c}", width: "150px" },
        {
            template: "<div class='model-photo'" +
                "style='background-image: url(#:data.photo#);'></div>",
            field: "photo",
            title: "Photo",
            width: "40%"
        },
        { field: "carBrandId", title: "CarBrandId", width: "220px" },
        { command: ["destroy"], title: "&nbsp;", width: "120px" }
    ],
    editable: true
});


$("#secondgrid tbody").on("click", "tr", function (e) {
    var gview = $("#maingrid").data("kendoGrid");
    var selectedItem = gview.dataItem(gview.select());
    if (selectedItem == null)
        return;
    selCarModelId = selectedItem.id;
    var sec = $("#thigrid").data("kendoGrid");
    sec.dataSource.read();
    sec.dataSource.filter({s
        field: "id",
        operator: "eq",
        value: selCarModelId
    });
    sec.dataSource.query({
        filter: {
            field: "id",
            operator: "eq",
            value: selCarModelId
        }, pageSize: 5, page: 1
    });
    sec.refresh();
    document.getElementById("selCarModelId").innerText = selCarModelId;
});


$("#thigrid").kendoGrid({
    dataSource: {
        transport: {
            read: {
                url: crudCarPhotoBaseUrl,
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8"
            },
            update: {
                type: "PUT",
                url: function (data) {
                    return crudCarPhotoBaseUrl + data.id;
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            destroy: {
                type: "DELETE",
                url: function (data) {
                    return crudCarPhotoBaseUrl + data.id;
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            create: {
                type: "POST",
                url: crudCarPhotoBaseUrl,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && operation !== "destroy" && options.models) {
                    if (operation !== "create")
                        return kendo.stringify(options);

                    data.id = kendo.guid();
                    return options;
                }
                return kendo.data.transports["odata-v4"].parameterMap(options, operation);
            }
        },
        schema: {
            model: {
                id: "id",
                fields: {
                    Photo: {
                        type: "string"
                    },
                    carModelId: {
                    }
                }
            }
        },
        serverPaging: true,
        serverSorting: true,
        serverFiltering: true,
        pageSize: 5/*,
                filter: {
                    field: "id",
                    operator: "eq",
                    value: selCarModelId
                }*/
    },
    selectable: "row",
    scrollable: true,
    sortable: false,
    pageable: true,
    height: 400,
    toolbar: ["create"],
    columns: [
        {
            template: "<div class='model-photo'" +
                "style='background-image: url(#:data.photo#);'></div>",
            field: "photo",
            title: "Photo",
            width: "40%"
        },
        { field: "carModelId", title: "carModelId", width: "220px" },
        { command: ["destroy"], title: "&nbsp;", width: "120px" }
    ],
    editable: "popup"
});

        //function categoryDropDownEditor(container, options) {
        //    $('<input required name="' + options.field + '"/>')
        //        .appendTo(container)
        //        .kendoDropDownList({
        //            autoBind: false,
        //            dataTextField: "name",
        //            dataValueField: "id",
        //            dataSource: {
        //                transport: {
        //                    url: crudCarModelBaseUrl,
        //                    dataType: "json",
        //                    type: "GET",
        //                    contentType: "application/json; charset=utf-8"
        //                }
        //            }
        //        });
        //}