var ajaxRequester = (function () {
    var baseUrl = 'https://api.parse.com/1/';

    var headers = {
        "X-Parse-Application-Id": "cqVKdcHMQvcrQoOmoQZx3WuCPKezNWVkCW3DEfML",
        "X-Parse-REST-API-Key": "7hPZT2NjslSuOyqDEcPcR5BVK0lRkBsvZR8Z4XqC"
    };

    function register(username, password, success, error) {
        jQuery.ajax({
            method: 'POST',
            headers: headers,
            url: baseUrl + 'users',
            contentType: 'application/json',
            data: JSON.stringify({username: username, password: password}),
            success: success,
            error: error
        });
    }

    function login(username, password, success, error) {
        jQuery.ajax({
            method: 'GET',
            headers: headers,
            url: baseUrl + 'login',
            contentType: 'application/json',
            data: {username: username, password: password},
            success: success,
            error: error
        });
    }

    function getHeadersWithSessionToken(sessionToken) {
        var headersWithToken = JSON.parse(JSON.stringify(headers));
        headersWithToken['X-Parse-Session-Token'] = sessionToken;
        return headersWithToken;
    }

    function listProducts(sessionToken, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        jQuery.ajax({
            method: 'GET',
            headers: headersWithToken,
            url: baseUrl + 'classes/Product',
            contentType: 'application/json',
            success: success,
            error: error
        });
    }

    function addProduct(name, category, price, userId, success, error) {
        var product = {name: name, category: category, price: price, ACL: {}};
        product.ACL['*'] = {'read': true};
        product.ACL[userId] = {'write': true, 'read': true};
        jQuery.ajax({
            method: 'POST',
            headers: headers,
            url: baseUrl + 'classes/Product',
            contentType: 'application/json',
            data: JSON.stringify(product),
            success: success,
            error: error
        });
    }

    function editProduct(name, category, price, sessionToken, productId, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        jQuery.ajax({
            method: 'PUT',
            headers: headersWithToken,
            url: baseUrl + 'classes/Product/' + productId,
            contentType: 'application/json',
            data: JSON.stringify({name: name, category: category, price: price}),
            success: success,
            error: error
        });
    }

    function deleteProduct(sessionToken, productId, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        jQuery.ajax({
            method: 'DELETE',
            headers: headersWithToken,
            url: baseUrl + 'classes/Product/' + productId,
            contentType: 'application/json',
            success: success,
            error: error
        });
    }

    return {
        register: register,
        login: login,
        listProducts: listProducts,
        addProduct: addProduct,
        editProduct: editProduct,
        deleteProduct: deleteProduct
    };
}());