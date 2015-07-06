(function () {
    $(function () {
        registerEventHandlers();

        var currentUser = userSession.getCurrentUser();
        if (currentUser) {
            showUserHomeView()
        } else {
            showGuestHomeView();
        }
    });

    function registerEventHandlers() {
        $('#btnShowGuestHomeView').click(showGuestHomeView);
        $('#btnShowUserHomeView').click(showUserHomeView);

        $('#btnShowLoginView').click(showLoginView);
        $('#lnkShowLoginView').click(showLoginView);
        $('#linkShowLoginView').click(showLoginView);

        $('#btnShowRegisterView').click(showRegisterView);
        $('#lnkShowRegisterView').click(showRegisterView);

        $('#btnShowProductsView').click(showProductsView);
        $('.button').click(showProductsView);
        $('#btnShowAddProductView').click(showAddProductView);

        $(function() {
            $(document).on("click", '.edit-button', showEditProductView);
        });
        $(function() {
            $(document).on("click", '.delete-button', showDeleteProductView);
        });

        $('#register-button').click(registerButtonClicked);
        $('#login-button').click(loginButtonClicked);
        $('#btnLogout').click(logoutButtonClicked);
        $('#add-product-button').click(addProductButtonClicked);
        $('#delete-product-button').click(deleteProductButtonClicked);
        $('#edit-product-button').click(editProductButtonClicked);
    }

    function showGuestHomeView() {
        $('#userMenu').hide();
        $('#guestMenu').show();
        $('#main > *').hide();
        $('#guestHomeView').show();
    }

    function showUserHomeView() {
        $('#guestMenu').hide();
        $('#userMenu').show();
        $('#main > *').hide();
        $('#userHomeView').show();
        var currentUser = userSession.getCurrentUser();
        $('#username').text(currentUser.username);
    }

    function showRegisterView() {
        $('#userMenu').hide();
        $('#guestMenu').show();
        $('#main > *').hide();
        $('#registerView').show();
    }

    function showLoginView() {
        $('#userMenu').hide();
        $('#guestMenu').show();
        $('#main > *').hide();
        $('#loginView').show();
    }

    function showAddProductView() {
        $('#guestMenu').hide();
        $('#userMenu').show();
        $('#main > *').hide();
        $('#addProductView').show();
    }

    function showDeleteProductView() {
        $('#guestMenu').hide();
        $('#userMenu').show();
        $('#main > *').hide();
        $('#deleteProductView').show();
    }

    function showEditProductView() {
        $('#guestMenu').hide();
        $('#userMenu').show();
        $('#main > *').hide();
        $('#editProductView').show();
    }

    function showProductsView() {
        $('#guestMenu').hide();
        $('#userMenu').show();
        $('#main > *').hide();
        $('#productsView').show();
        var sessionToken = userSession.sessionToken;
        ajaxRequester.listProducts(sessionToken, loadProducts, loadProductsError);
    }

    function loadProducts(data) {
        var productsUl = $('#products');
        productsUl.html('');
        for (var p in data.results) {
            var product = data.results[p];
            var productLi = $('<li class="product"><div class="product-info">');
            productLi.data('product', product);

            var name = $('<p class="item-name">');
            name.text(product.name);
            productLi.append(name);

            var category = $('<p class="category"><span class="pre">Category:</span>');
            category.text(product.category);
            productLi.append(category);

            var price = $('<p class="price"><span class="pre">Price:</span>');
            price.text(product.price);
            productLi.append(price);

            var footer = $('<footer class="product-footer"><a href="#"><button class="edit-button">Edit</button><a href="#"><button class="delete-button">Delete</button>');
            productLi.append(footer);
            productsUl.append(productLi);
        }
    }

    function registerButtonClicked() {
        var username = $('#registerUsername').val();
        var password = $('#registerPassword').val();
        var confirmPassword = $('#confirm-password').val();
        if (password !== confirmPassword) {
            registerError();
        }

        ajaxRequester.register(username, password,
            function (data) {
                data.username = username;
                authSuccess(data);
                showLoginView();
            },
            registerError);

        registerMsg();
    }

    function loginButtonClicked() {
        var username = $('#loginUsername').val();
        var password = $('#loginPassword').val();
        ajaxRequester.login(username, password, authSuccess, loginError);
        loginMsg();
    }

    function logoutButtonClicked() {
        userSession.logout();
        showGuestHomeView();
        logoutMsg();
    }

    function addProductButtonClicked() {
        var name = $('#name').val();
        var category = $('#category').val();
        var price = $('#price').val();
        var currentUser = userSession.getCurrentUser();
        ajaxRequester.addProduct(name, category, price, currentUser.objectId, showProductsView, addProductError);
        addProductMsg();
    }

    function deleteProductButtonClicked() {
        var product = $(this).parent().data('product');
        var currentUser = userSession.getCurrentUser();
        var sessionToken = currentUser.sessionToken;

        noty(
            {
                text: "Delete this product?",
                type: 'confirm',
                layout: 'topCenter',
                buttons: [
                    {
                        text : "Yes",
                        onClick : function($noty) {
                            deleteProduct(sessionToken, product);
                            $noty.close();
                        }
                    },
                    {
                        text : "Cancel",
                        onClick : function($noty) {
                            $noty.close();
                        }
                    }
                ]
            }
        );
    }

    function deleteProduct(sessionToken, product) {
        ajaxRequester.deleteProduct(sessionToken, product.objectId, showProductsView, deleteProductError);
        deleteProductMsg();
    }

    function editProductButtonClicked() {
        var name = $('#name').val();
        var category = $('#category').val();
        var price = $('#price').val();
        var currentUser = userSession.getCurrentUser();
        var sessionToken = currentUser.sessionToken;
        var product = $(this).parent().data('product');
        ajaxRequester.editProduct(name, category, price, sessionToken, product.objectId, showProductsView, editProductError);
        editProductMsg();
    }

    function authSuccess(data) {
        userSession.login(data);
        showProductsView();
    }

    function deleteProductMsg() {
        showInfoMessage('Deleted a product successfully.')
    }

    function editProductMsg() {
        showInfoMessage('Edited a product successfully.')
    }

    function addProductMsg() {
        showInfoMessage('Added a product successfully.')
    }

    function registerMsg() {
        showInfoMessage('Registration successful.')
    }

    function loginMsg() {
        showInfoMessage('Login successful.')
    }

    function logoutMsg() {
        showInfoMessage('Logout successful.')
    }

    function registerError(error) {
        showAjaxError("Register failed", error);
    }

    function loginError(error) {
        showAjaxError("Login failed", error);
    }

    function addProductError(error) {
        showErrorMessage("Product create failed.");
    }

    function deleteProductError(error) {
        showErrorMessage("Delete product failed.");
    }

    function editProductError(error) {
        showErrorMessage("Edit product failed.");
    }

    function loadProductsError(error) {
        showErrorMessage("Products load failed.");
    }

    function showAjaxError(msg, error) {
        var errMsg = error.responseJSON;
        if (errMsg && errMsg.error) {
            showErrorMessage(msg + ": " + errMsg.error);
        } else {
            showErrorMessage(msg + ".");
        }
    }

    function showInfoMessage(msg) {
        noty({
                text: msg,
                type: 'info',
                layout: 'topCenter',
                timeout: 5000}
        );
    }

    function showErrorMessage(msg) {
        noty({
                text: msg,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000}
        );
    }
}());