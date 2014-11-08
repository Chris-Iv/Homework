define(function () {
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var ListModuleElement = (function () {
        var ListModuleElement = function ListModuleElement(title) {
            this.setTitle(title);
        };

        ListModuleElement.prototype.getTitle = function (title) {
            return this._title;
        };

        ListModuleElement.prototype.setTitle = function (title) {
            this.validateNullOrEmpty(title, 'title');
            this._title = title;
            return this;
        };

        return ListModuleElement;
    }());

    return ListElement;
});