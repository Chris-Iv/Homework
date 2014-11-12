function processRestaurantManagerCommands(commands) {
    'use strict';

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    function isNullOrEmpty(value) {
        if (!value || typeof value === 'undefined' || value === null) {
            return true;
        }

        return false;
    }

    function isNotPositive(number) {
        if (number < 0) {
            return true;
        }

        return false;
    }

    function isGreaterThanConstant(value, constant) {
        if (value > constant) {
            return true;
        }

        return false;
    }

    var RestaurantEngine = (function () {
        var _restaurants, _recipes;

        function initialize() {
            _restaurants = [];
            _recipes = [];
        }


        var Restaurant = (function () {
            var Restaurant = function Restaurant(name, location) {
                this.setName(name);
                this.setLocation(location);
                this._recipes = [];
            };

            Restaurant.prototype.getName = function () {
                return this._name;
            };

            Restaurant.prototype.setName = function (name) {
                if (isNullOrEmpty(name)) {
                    throw new Error('The name is required.');
                }

                this._name = name;
            };

            Restaurant.prototype.getLocation = function () {
                return this._location;
            };

            Restaurant.prototype.setLocation = function (location) {
                this._location = location;
            };

            Restaurant.prototype.addRecipe = function (recipe) {
                this._recipes.push(recipe);
            };

            Restaurant.prototype.removeRecipe = function (recipe) {
                var index = this._recipes.indexOf(recipe);
                this._recipes.splice(index, 1);
            };

            Restaurant.prototype.printRestaurantMenu = function () {
                var drinks = new String;
                var salads = new String;
                var mainCourses = new String;
                var desserts = new String;

                var length = this._recipes.length;

                var result = '***** ' + this.getName() + ' - ' + this.getLocation() + ' *****' + '\n';
                if (length == 0) {
                    result += 'No recipes... yet' + '\n';
                } else {
                    this._recipes.sort(function (a, b) {
                        if (a.getName() < b.getName) {
                            return -1;
                        } else if (a.getName() > b.getName) {
                            return 1;
                        }

                        return 0;
                    });

                    for (var i = 0; i < length; i++) {
                        var current = this._recipes[i];
                        if (current instanceof Drink) {
                            drinks += current.toString();
                        } else if (current instanceof Salad) {
                            salads += current.toString();
                        } else if (current instanceof MainCourse) {
                            mainCourses += current.toString();
                        } else if (current instanceof Dessert) {
                            desserts += current.toString();
                        }
                    }

                    if (drinks.length > 0) {
                        result += "~~~~~ DRINKS ~~~~~\n" + drinks;
                    }
                    if (salads.length > 0) {
                        result += "~~~~~ SALADS ~~~~~\n" + salads;
                    }
                    if (mainCourses.length > 0) {
                        result += "~~~~~ MAIN COURSES ~~~~~\n" + mainCourses;
                    }
                    if (desserts.length > 0) {
                        result += "~~~~~ DESSERTS ~~~~~\n" + desserts;
                    }
                }

                return result;
            };

            return Restaurant;
        }());


        var Recipe = (function () {
            var Recipe = function Recipe(name, price, calories, quantityPerServing, unit, time) {
                if (this.constructor === Recipe) {
                    throw new Error('Cannot instantiate abstract class Recipe.');
                }

                this.setName(name);
                this.setPrice(price);
                this.setCalories(calories);
                this.setQuantityPerServing(quantityPerServing);
                this.setUnit(unit);
                this.setTime(time);
            };

            Recipe.prototype.getName = function () {
                return this._name;
            };

            Recipe.prototype.setName = function (name) {
                if (isNullOrEmpty(name)) {
                    throw new Error('The name is required.');
                }

                this._name = name;
            };

            Recipe.prototype.getPrice = function () {
                return this._price;
            };

            Recipe.prototype.setPrice = function (price) {
                if (isNotPositive(price)) {
                    throw new Error('The price must be positive.');
                }

                if (this.constructor === Drink) {
                    if (isGreaterThanConstant(price, 100)) {
                        throw new Error('Price for drink cannot be greater than 20.');
                    }
                }

                this._price = price;
            };

            Recipe.prototype.getCalories = function () {
                return this._calories;
            };

            Recipe.prototype.setCalories = function (calories) {
                if (isNotPositive(calories)) {
                    throw new Error('The calories must be positive.');
                }

                this._calories = calories;
            };

            Recipe.prototype.getQuantityPerServing = function () {
                return this._quantityPerServing;
            };

            Recipe.prototype.setQuantityPerServing = function (quantityPerServing) {
                if (isNotPositive(quantityPerServing)) {
                    throw new Error('The quantity per serving must be positive.');
                }

                this._quantityPerServing = quantityPerServing;
            };

            Recipe.prototype.getUnit = function () {
                return this._unit;
            };

            Recipe.prototype.setUnit = function (unit) {
                this._unit = unit;
            };

            Recipe.prototype.getTime = function () {
                return this._time;
            };

            Recipe.prototype.setTime = function (time) {
                if (isNotPositive(time)) {
                    throw new Error('The time must be positive.');
                }

                if (this.constructor === Drink) {
                    if (isGreaterThanConstant(time, 20)) {
                        throw new Error('Time for drink cannot be greater than 20.');
                    }
                }

                this._time = time;
            };

            Recipe.prototype.toString = function () {
              var result = '==  ' + this.getName() + ' == $' + this.getPrice().toFixed(2) + '\n' +
                'Per serving: ' + this.getQuantityPerServing() + ' ' + this.getUnit() + ', ' + this.getCalories() + ' kcal' + '\n' +
                'Ready in ' + this.getTime() + ' minutes';

                return result;
            };

            return Recipe;
        }());


        var Drink = (function () {
            var Drink = function Drink(name, price, calories, quantityPerServing, unit, time, isCarbonated) {
                Recipe.call(this, name, price, calories, quantityPerServing, 'ml', time);
                this.setIsCarbonated(isCarbonated);
            };

            Drink.extends(Recipe);

            Drink.prototype.getIsCarbonated = function () {
                return this._isCarbonated;
            };

            Drink.prototype.setIsCarbonated = function (isCarbonated) {
                this._isCarbonated = isCarbonated;
            };

            Drink.prototype.toString = function () {
              var carbonated = this.getIsCarbonated() ? 'yes' : 'no';
              return Recipe.prototype.toString.call(this) + '\n' +
                      'Carbonated: ' + carbonated + '\n';
            };

            return Drink;
        }());


        var Meal = (function () {
            var Meal = function Meal(name, price, calories, quantityPerServing, unit, time, isVegan) {
                if (this.constructor === Meal) {
                    throw new Error('Cannot instantiate abstract class Meal.');
                }

                Recipe.call(this, name, price, calories, quantityPerServing, 'g', time);
                this.setIsVegan(isVegan);
            };

            Meal.extends(Recipe);

            Meal.prototype.getIsVegan = function () {
                return this._isVegan;
            };

            Meal.prototype.setIsVegan = function (isVegan) {
                this._isVegan = isVegan;
            };

            Meal.prototype.toggleVegan = function () {
                if (this.constructor === Salad) {
                    throw new Error('The salad is always vegan.');
                }

                this._isVegan = !this._isVegan;
            };

            Meal.prototype.toString = function () {
                var vegan = this.getIsVegan() ? '[VEGAN] ' : '';
                return vegan + Recipe.prototype.toString.call(this);
            };

            return Meal;
        }());


        var Dessert = (function () {
            var Dessert = function Dessert(name, price, calories, quantityPerServing, unit, time, isVegan, hasSugar) {
                Meal.call(this, name, price, calories, quantityPerServing, unit, time, isVegan);
                this.setHasSugar(hasSugar);
            };

            Dessert.extends(Meal);

            Dessert.prototype.getHasSugar = function () {
                return this._hasSugar;
            };

            Dessert.prototype.setHasSugar = function (hasSugar) {
                this._hasSugar = hasSugar;
            };

            Dessert.prototype.toggleSugar = function () {
                this._withSugar = !this._withSugar;
            };

            Dessert.prototype.toString = function () {
                var sugar = this.getHasSugar() ? '' : '[NO SUGAR] ';
                return sugar + Meal.prototype.toString.call(this) + '\n';
            };

            return Dessert;
        }());


        var MainCourse = (function () {
            var MainCourse = function MainCourse(name, price, calories, quantityPerSeving, time, isVegan, type) {
                Meal.call(this, name, price, calories, quantityPerSeving, time, isVegan);
                this.setType(type);
            };

            MainCourse.extends(Meal);

            MainCourse.prototype.getType = function () {
                return this._type;
            };

            MainCourse.prototype.setType = function (type) {
                this._type = type;
            };

            MainCourse.prototype.toString = function () {
                return Meal.prototype.toString.call(this) + '\n' +
                        'Type: ' + this.getType() + '\n';

            };

            return MainCourse;
        }());


        var Salad = (function () {
            var Salad = function Salad(name, price, calories, quantityPerServing, unit, time, isVegan, containsPasta) {
                Meal.call(this, name, price, calories, quantityPerServing, unit, time, true);
                this.setContainsPasta(containsPasta);
            };

            Salad.extends(Meal);

            Salad.prototype.getContainsPasta = function () {
                return this._containsPasta;
            };

            Salad.prototype.setContainsPasta = function (containsPasta) {
                this._containsPasta = containsPasta;
            };

            Salad.prototype.toString = function () {
                var pasta = this.getContainsPasta() ? 'yes' : 'no';
                return Meal.prototype.toString.call(this) + '\n' +
                        'Contains pasta: ' + pasta + '\n';
            };

            return Salad;
        }());


        var Command = (function () {

            function Command(commandLine) {
                this._params = new Array();
                this.translateCommand(commandLine);
            }

            Command.prototype.translateCommand = function (commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");

                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function (e) { return true });

                parametersKeysAndValues.forEach(function (p) {
                    var split = p
                        .split("=")
                        .filter(function (e) { return true; });
                    self._params[split[0]] = split[1];
                });
            }

            return Command;
        }());

        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }

        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }

        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }

        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }

        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }

        function toggleSugar(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];

            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }

        function toggleVegan(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }

            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }

        function printRestaurantMenu(name) {
            var restaurant;

            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }

            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }

        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }

        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }

        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;

            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }

            return result;
        }

        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });

    return results.trim();
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function() {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function(line) {
            arr.push(line);
        }).on('close', function() {
            console.log(processRestaurantManagerCommands(arr));
        });
    }
})();
