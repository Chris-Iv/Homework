define(["ListElement"], function (ListElement) {
    var Section = (function () {
        var counter = 0;
        var Section = function Section(title, items) {
            ListModuleElement.call(this, title);
            this.setItems(items);
            counter++;
        };

        Section.extends(ListModuleElement);

        Section.prototype.getItems = function () {
            return this._items;
        };

        Section.prototype.setItems = function (items) {
            this._items = items;
            return this;
        };

        Section.prototype.addToDOM = function () {
            var target = document.getElementById('sectionContainer');
            var newElement = document.createElement('DIV');
            newElement.innerHTML =
                '<section class="clearfix" id="section' + counter +'">' +
                '<h2>' + this.getTitle() + '</h2>' +
                '</section>' +
                '<div class="addItem clearfix">' +
                '<input type="text" id="newitemfield' + counter +'" placeholder="Add item..." />' +
                '<button href="#" class="addNewItem" onclick="addNewItem(\'section' + counter +'\', \'newitemfield' + counter +'\')" >+</button>' +
                '</div>';
            target.appendChild(newElement);
        };

        Section.prototype.addItem = function (item) {
            this._items.push(item);
        };

        return Section;
    }());

    return Section;
});