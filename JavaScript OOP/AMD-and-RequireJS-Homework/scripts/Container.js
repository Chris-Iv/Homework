define(["ListElement"], function (ListElement) {

    var Container = (function () {
        var Container = function Container(title, sections) {
            ListModuleElement.call(this, title);
            this.setSections(sections);
        };

        Container.extends(ListModuleElement);

        Container.prototype.getSections = function () {
            return this._sections;
        };
        
        Container.prototype.setSections = function (sections) {
            this._sections = sections;
            return this;
        };

        Container.prototype.addSection = function (section) {
            this._sections.push(section);
        };

        Container.prototype.addToDOM = function () {
          var target = document.getElementById('wrapper');
          var newElement = document.createElement('DIV');
          newElement.innerHTML =
              '<div id="container">' +
              '<h1>' + this.getTitle() + '</h1>' +
              '<div id="sectionContainer">' +
              '</div>' +
              '<input type="text" id="newSectionField" placeholder="Title..." />' +
              '<button class="addNewSection" onclick="addNewSection()">New Section</a>' +
              '</div>';
          target.appendChild(newElement);
        };

        return Container;
    }());

    return Container;
});

