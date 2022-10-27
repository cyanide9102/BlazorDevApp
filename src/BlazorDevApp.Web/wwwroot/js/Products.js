'use strict'

function initProductsDataTable() {
    $(document).ready(function () {
        $('#productsTable').DataTable()
    })
}

function destroyProductsDataTable() {
    $(document).ready(function () {
        $('#productsTable').DataTable().destroy()
    })
}
