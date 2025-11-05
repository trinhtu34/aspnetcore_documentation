(function ($) {
    var _productService = abp.services.app.product;
    var l = abp.localization.getSource('myproject');
    var _$modal = $('#ProductCreateOrEditModal');
    var _$form = $('#ProductCreateOrEditForm');
    var _$table = $('#ProductsTable');

    var _dataTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        processing: true,
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _dataTable.ajax.reload()
            }
        ],
        ajax: function (data, callback, settings) {
            var filter = {
                keyword: $('#SearchKeyword').val(),
                maxResultCount: data.length,
                skipCount: data.start
            };

            abp.ui.setBusy(_$table);
            _productService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        columnDefs: [
            {
                targets: 0,
                data: 'name'
            },
            {
                targets: 1,
                data: 'description',
                render: function (data) {
                    return data || '-';
                }
            },
            {
                targets: 2,
                data: 'price',
                render: function (data) {
                    return '$' + data.toFixed(2);
                }
            },
            {
                targets: 3,
                data: 'stock'
            },
            {
                targets: 4,
                data: 'isActive',
                render: function (data) {
                    return data ? '<span class="badge badge-success">' + l('Yes') + '</span>' : '<span class="badge badge-secondary">' + l('No') + '</span>';
                }
            },
            {
                targets: 5,
                data: null,
                orderable: false,
                autoWidth: false,
                render: function (data, type, row) {
                    var buttons = '';
                    
                    if (abp.auth.isGranted('Pages.Products.Edit')) {
                        buttons += '<button class="btn btn-sm btn-primary edit-product" data-id="' + row.id + '" title="' + l('Edit') + '"><i class="fa fa-edit"></i></button> ';
                    }
                    
                    if (abp.auth.isGranted('Pages.Products.Delete')) {
                        buttons += '<button class="btn btn-sm btn-danger delete-product" data-id="' + row.id + '" title="' + l('Delete') + '"><i class="fa fa-trash"></i></button>';
                    }
                    
                    return buttons;
                }
            }
        ]
    });

    // Create button
    $('#CreateNewProductButton').click(function () {
        _$form[0].reset();
        $('#ProductId').val('');
        $('#ProductCreateOrEditModalLabel').text(l('CreateNewProduct'));
        _$modal.modal('show');
    });

    // Edit button
    _$table.on('click', '.edit-product', function () {
        var productId = $(this).data('id');
        
        _productService.get({ id: productId }).done(function (result) {
            $('#ProductId').val(result.id);
            $('#ProductName').val(result.name);
            $('#ProductDescription').val(result.description);
            $('#ProductPrice').val(result.price);
            $('#ProductStock').val(result.stock);
            $('#ProductIsActive').prop('checked', result.isActive);
            $('#ProductCreateOrEditModalLabel').text(l('EditProduct'));
            _$modal.modal('show');
        });
    });

    // Save button
    $('#SaveProductButton').click(function () {
        if (!_$form.valid()) {
            return;
        }

        var product = {
            name: $('#ProductName').val(),
            description: $('#ProductDescription').val(),
            price: parseFloat($('#ProductPrice').val()),
            stock: parseInt($('#ProductStock').val()),
            isActive: $('#ProductIsActive').is(':checked')
        };

        var productId = $('#ProductId').val();

        abp.ui.setBusy(_$modal);

        if (productId) {
            // Update
            product.id = productId;
            _productService.update(product).done(function () {
                _$modal.modal('hide');
                _dataTable.ajax.reload();
                abp.notify.success(l('SavedSuccessfully'));
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        } else {
            // Create
            _productService.create(product).done(function () {
                _$modal.modal('hide');
                _dataTable.ajax.reload();
                abp.notify.success(l('SavedSuccessfully'));
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        }
    });

    // Delete button
    _$table.on('click', '.delete-product', function () {
        var productId = $(this).data('id');
        var productName = $(this).closest('tr').find('td:first').text();

        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete'), productName),
            l('Delete'),
            function (isConfirmed) {
                if (isConfirmed) {
                    _productService.delete({ id: productId }).done(function () {
                        _dataTable.ajax.reload();
                        abp.notify.success(l('SuccessfullyDeleted'));
                    });
                }
            }
        );
    });

    // Search button
    $('#SearchButton').click(function () {
        _dataTable.ajax.reload();
    });

    // Refresh button
    $('#RefreshButton').click(function () {
        $('#SearchKeyword').val('');
        _dataTable.ajax.reload();
    });

    // Enter key in search box
    $('#SearchKeyword').keypress(function (e) {
        if (e.which === 13) {
            _dataTable.ajax.reload();
        }
    });
})(jQuery);
