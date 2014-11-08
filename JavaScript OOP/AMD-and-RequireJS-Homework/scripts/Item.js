define(["ListElement"], function (ListElement) {
    var Item = (function () {
        var counter = 0;
        var Item = function Item(title) {
            ListModuleElement.call(this, title);
            counter++;
        };

        Item.extends(ListModuleElement);

        Item.prototype.addToDOM = function (target) {
            var target = document.getElementById(target);
            var newElement = document.createElement("DIV");
            newElement.innerHTML =
                '<div class="contentBox">' +
                '<input onclick="changeStatus(content' + counter + ')" type="checkbox" />'+
                '<div class="content" id="content' + counter + '">' + this.getTitle() +'</div>' +
                '</div>';
            target.appendChild(newElement);
        };

        return Item;
    }());

    return Item;
});

