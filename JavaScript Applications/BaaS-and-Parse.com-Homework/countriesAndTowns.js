$(function () {
    var PARSE_APP_ID = 'y1dRPRBXJIHNDzIK8drI5poMx9oMbOn9FYQbdl11';
    var PARSE_REST_API_KEY = 'uIbxloYbQXzMDfJh3RfGA2qVEwjlabay3znx55Ub';

    loadCountries();

    function loadCountries() {
        $.ajax({
            method: 'GET',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            url: 'https://api.parse.com/1/classes/Country',

            success: countiesLoaded,
            error: error
        });
    }

    function countiesLoaded(data) {
        $('body').empty();
        $('body').append('<h2>Countries</h2>')
            .append('<input type="text" id="add-country-text" />')
            .append('<a id="add-country-button" href="#">Add a country</a>')
            .append('<ul class="countries"></ul>');
        $('#add-country-button').click(addCountry);

        for (var c in data.results) {
            var country = data.results[c];
            var countryItem = $('<li></li>');
            var countryLink = $('<a href="#"></a>');

            countryLink.data('country', country);
            countryLink.click(loadTowns);
            countryLink.text(country.name);
            countryLink.appendTo(countryItem);

            addButtons(countryItem, country);

            countryItem.appendTo($(".countries"));
        }
        $('.edit-country').click(editCountry);
    }

    function addButtons(countryItem, country) {
        var removeButton = $('<a id="remove-button" href="#">Remove country</a>');
        removeButton.data('country', country);
        removeButton.click(removeCountry);

        var editButton = $('<a id="edit-button" href="#">Edit country</a>');
        editButton.data('country', country);
        editButton.click(editCountry);

        countryItem.append(' ')
            .append(editButton)
            .append(' ')
            .append(removeButton);
    }

    function addCountry() {
        var countryName = $('#add-country-text').val();

        $.ajax({
            method: 'POST',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            data: JSON.stringify(
                {'name': countryName}
            ),

            contentType: 'application/json',

            url: 'https://api.parse.com/1/classes/Country',

            success: loadCountries,
            error: error
        });
    }

    function editCountry() {
        var country = $(this).data('country');
        var oldCountryName = country.name;
        var newCountryName = prompt('Rename country:', oldCountryName || oldCountryName);

        $.ajax({
            method: 'PUT',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            data: JSON.stringify(
                {'name': newCountryName}
            ),

            contentType: 'application/json',

            url: 'https://api.parse.com/1/classes/Country/' + country.objectId,

            success: loadCountries,
            error: error
        });
    }

    function removeCountry() {
        var country = $(this).data('country');

        $.ajax({
            method: 'DELETE',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            url: 'https://api.parse.com/1/classes/Country/' + country.objectId,

            success: loadCountries,
            error: error
        });
    }

    function loadTowns() {
        var country = $(this).data('country');

        if (!$(this).parent().has('ul').length) {
            var targetLi = $('li:contains(' + country.name + ')');
            var townName = $('<input type="text" id="add-town-text"/>');
            var addTownButton = $('<a id="add-town-button" href="#">Add a town</a>');
            addTownButton.data('country', country);
            addTownButton.data('townName', townName);
            addTownButton.click(addTown);
            targetLi.append(townName).append(addTownButton);
        }

        $.ajax({
            method: 'GET',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + country.name + '"}}',

            success: townsLoaded,
            error: error
        });
    }

    function townsLoaded(data){
        var country = data.results[0].country;
        var targetLi = $("li:contains('" + country.objectId + "')");

        if(targetLi.has('ul').length) {
            $('"' + targetLi + " ul").empty();
        }

        var townsUl = $('<ul>');
        for (var t in data.results){
            var town = data.results[t];

            var editTownButton = $('<a href="#">Edit</a>');
            editTownButton.data('town', town);
            editTownButton.click(editTown);

            var removeTownButton = $('<a href="#">Remove</a>');
            removeTownButton.data('town', town);
            removeTownButton.click(removeTown);

            townsUl.append($('<li>' + town.name + '</li>'))
                .append(editTownButton)
                .append(' ')
                .append(removeTownButton);
        }

        townsUl.appendTo(targetLi);
    }
    function addTown(){
        var townName = $(this).data('townName').val();
        var country = $(this).data('country');

        $.ajax({
            method: "POST",

            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },

            data: JSON.stringify(
                {
                    "name": townName,
                    "country":
                    {
                        "__type": "Pointer",
                        "className": "Country",
                        "objectId": country.objectId
                    }
                }
            ),

            contentType: "application/json",

            url: "https://api.parse.com/1/classes/Town",

            success: loadCountries,
            error: error
        });
    }

    function editTown() {
        var town = $(this).data('town');
        var oldTownName = town.name;
        var newTownName = prompt('Rename town:', oldTownName || oldTownName);

        $.ajax({
            method: 'PUT',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            data: JSON.stringify(
                {
                    'name': newTownName
                }
            ),

            contentType: 'application/json',

            url: 'https://api.parse.com/1/classes/Town/' + town.objectId,

            success: loadCountries,
            error: error
        });
    }

    function removeTown() {
        var town = $(this).data('town');

        $.ajax({
            method: 'DELETE',

            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY
            },

            url: 'https://api.parse.com/1/classes/Town/' + town.objectId,

            success: loadCountries,
            error: error
        });
    }

    function error() {
        alert('Cannot load AJAX data.');
    }
});