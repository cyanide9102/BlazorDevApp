export function initProductsDataTable() {
    $(document).ready(function () {
        var table = $('#productsTable').DataTable({
            paging: true,
            processing: true,
            serverSide: true,
            search: {
                return: true
            },
            searching: false,
            ajax: {
                url: 'https://localhost:7701/api/Products/GetAll',
                type: 'POST',
                error: function (e) {
                    console.error({ ...e.responseJSON })
                    table.processing(false)
                }
            },
            columns: [
                {
                    data: 'id',
                    name: 'Id'
                },
                {
                    data: 'name',
                    name: 'Name'
                },
                {
                    data: 'price',
                    name: 'Price',
                    render: function (data, _type, _row, _meta) {
                        return `$${data}`
                    }
                },
                {
                    data: 'createdOn',
                    name: 'CreatedOn',
                    render: function (data, _type, _row, _meta) {
                        return moment(new Date(data)).format('Do MMMM, YYYY')
                    }
                },
                {
                    data: 'id',
                    name: 'Actions',
                    orderable: false,
                    searchable: false,
                    className: 'text-end',
                    render: function (data, _type, row, _meta) {
                        return `<a href="product/${data}" class="btn btn-sm btn-primary"><span class="oi oi-info"></span> View</a>
                                <a href="edit-product/${data}" class="btn btn-sm btn-secondary"><span class="oi oi-cog"></span> Edit</a>
                                <button class="btn btn-sm btn-danger productDeleteBtn" data-product-id="${data}"><span class="oi oi-trash"></span> Delete</button>`
                    }
                },
            ],
            initComplete: function () {
                $('#productsFilters').on('submit', function (e) {
                    e.preventDefault()

                    var searchByName = $('#searchByName').val()
                    if (!!searchByName && table.columns(0).search() != searchByName) {
                        table.columns(0).search(searchByName).draw()
                    } else {
                        table.columns(0).search('').draw()
                    }
                })
            },
        })

        // Handle delete action
        $('#productsTable').on('click', '.productDeleteBtn', function () {
            var productId = $(this).data('product-id')

            $.ajax({
                type: 'DELETE',
                url: 'https://localhost:7701/api/Products/Delete/' + productId,
                //beforeSend: function (jqXHR) {
                    //jqXHR.setRequestHeader('RequestVerificationToken', $("[name='__RequestVerificationToken']").val())
                //},
                success: function (_data, _textStatus, _jqXHR) {
                    $.notify('Product deleted!', 'info')
                    $('#productsTable').DataTable().ajax.reload()
                },
                error: function (jqXHR, _textStatus, _errorThrown) {
                    $.notify(jqXHR.responseJSON.title, 'error')
                },
            })
        })
    })
}

export function destroyProductsDataTable() {
    $(document).ready(function () {
        $('#productsTable').DataTable().destroy()
    })
}
