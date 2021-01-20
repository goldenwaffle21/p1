var pizza;
var custom;
var cheese;
var hawaiian;
var meat;
var pesto;
var addtopping;
var remove;
var addpizza = document.querySelector("button[name=addpizza]");    
//only one add button, and it won't change, so we can define it permanently here
var pizzas;
var quantities;
var prices;

addPizzaListeners();

function addPizzaListeners()
{
    custom = document.querySelectorAll("input[type=radio][class=base][value=custom]");
    cheese = document.querySelectorAll("input[type=radio][class=base][value=cheese]");
    hawaiian = document.querySelectorAll("input[type=radio][class=base][value=hawaiian]");
    meat = document.querySelectorAll("input[type=radio][class=base][value=meat]");
    pesto = document.querySelectorAll("input[type=radio][class=base][value=pesto]");
    addtopping = document.querySelectorAll("button[name=addtopping]")
    remove = document.querySelectorAll("button[name=removepizza]");
    pizzas = document.querySelectorAll("section[name=pizzas]");
    quantities = document.querySelectorAll("input[type=number][class=quantity]");
    prices = document.querySelectorAll("input[class=price]");

    custom.forEach(item => {addCustomPizzaListener(item)});
    cheese.forEach(item => {addCheeseListener(item)});
    hawaiian.forEach(item => {addHawaiianListener(item)});
    meat.forEach(item => {addMeatListener(item)});
    pesto.forEach(item => {addPestoListener(item)});
    addtopping.forEach(item => {addAddToppingListener(item)})
    remove.forEach(item => {addRemoveListener(item)});
    quantities.forEach(item => {addQuantityListener(item)})
    prices.forEach(item => {addPriceListener(item)});
    calculateTotalPizzaNumber();
    calculateTotalPrice();
}

function addCustomPizzaListener(item)
{
    item.addEventListener('change', function()
    {
        pizza = item.parentElement;
        if (item.checked)
        {
            //switch toppings
            var toppings = pizza.getElementById("currenttoppings");
            removeAllChildNodes(toppings);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="cheese" value="cheese" />);
            var name = "toppings["+pizza.getElementById("number").value+"]";
            toppings.getElementById("cheese").setAttribute("name",name);
            toppings.appendChild(
                <label for="cheese">cheese</label>);
            //cheese topping is present to remind the user, but isn't checked by default
        }
        pizza.querySelector("input[class=price]").value = calculatePrice(pizza);
    });
}

function addCheeseListener(item)
{
    item.addEventListener('change', function()
    {
        pizza = item.parentElement;
        if (item.checked)
        {
            //switch toppings
            var toppings = pizza.getElementById("currenttoppings");
            removeAllChildNodes(toppings);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="cheese" value="cheese" checked></input>);
            var name = "toppings["+pizza.getElementById("number").value+"]";
            toppings.getElementById("cheese").setAttribute("name",name);
            toppings.appendChild(
                <label for="cheese">cheese</label>);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="extra cheese" value="extra cheese" checked></input>);
            toppings.getElementById("extra cheese").setAttribute("name",name);
            toppings.appendChild(
                <label for="cheese">cheese</label>);
        }
        pizza.querySelector("input[class=price]").value = calculatePrice(pizza);
    });
}

function addHawaiianListener(item)
{
    item.addEventListener('change', function()
    {
        pizza = item.parentElement;
        if (item.checked)
        {
            //switch toppings
            var toppings = pizza.getElementById("currenttoppings");
            removeAllChildNodes(toppings);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="Canadian bacon" value="Canadian bacon" checked></input>)
            var name = "toppings["+pizza.getElementById("number").value+"]";
            toppings.getElementById("Canadian bacon").setAttribute("name",name);
            toppings.appendChild(
                <label for="Canadian bacon">Canadian bacon</label>);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="cheese" value="cheese" checked></input>);
            toppings.getElementById("cheese").setAttribute("name",name);
            toppings.appendChild(
                <label for="cheese">cheese</label>);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="pineapples" value="pineapples" checked></input>);
            toppings.getElementById("pineapples").setAttribute("name",name);
            toppings.appendChild(
                <label for="pineapples">pineapples</label>);
        }
        pizza.querySelector("input[class=price]").value = calculatePrice(pizza);
    });
}

function addMeatListener(item)
{
    item.addEventListener('change', function()
    {
        pizza = item.parentElement;
        if (item.checked)
        {
            //switch toppings
            var toppings = pizza.getElementById("currenttoppings");
            removeAllChildNodes(toppings);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="cheese" value="cheese" checked></input>);
            var name = "toppings["+pizza.getElementById("number").value+"]";
            toppings.getElementById("cheese").setAttribute("name",name);
            toppings.appendChild(
                <label for="cheese">cheese</label>);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="peperoni" value="peperoni" checked></input>);
            toppings.getElementById("peperoni").setAttribute("name",name);
            toppings.appendChild(
                <label for="peperoni">peperoni</label>);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="sausage" value="sausage" checked></input>);
            toppings.getElementById("sausage").setAttribute("name",name);
            toppings.appendChild(
                <label for="sausage">sausage</label>);
        }
        pizza.querySelector("input[class=price]").value = calculatePrice(pizza);
    });
}

function addPestoListener(item)
{
    item.addEventListener('change', function()
    {
        pizza = item.parentElement;
        if (item.checked)
        {
            //switch sauce to pesto
            pizza.querySelector("input[class=sauce][value=pesto]").setAttribute(checked);

            //switch toppings
            var toppings = pizza.getElementById("currenttoppings");
            removeAllChildNodes(toppings);
            toppings.appendChild(
                <input type="checkbox" class="toppings" id="artichoke hearts" value="artichoke hearts" checked></input>);
            var name = "toppings["+pizza.getElementById("number").value+"]";
            toppings.getElementById("artichoke hearts").setAttribute("name",name);
            toppings.appendChild(
                <label for="artichoke hearts">artichoke hearts</label>);
            toppings.appendChild(
                <input type="checkbox" name="toppings" id="cheese" value="cheese" checked></input>);
            toppings.getElementById("cheese").setAttribute("name",name);
            toppings.appendChild(
                <label for="cheese">cheese</label>);
            toppings.appendChild(
                <input type="checkbox" name="toppings" id="feta" value="feta" checked></input>);
            toppings.getElementById("feta").setAttribute("name",name);
            toppings.appendChild(
                <label for="feta">feta</label>);
            toppings.appendChild(
                <input type="checkbox" name="toppings" id="garlic" value="garlic" checked></input>);
            toppings.getElementById("garlic").setAttribute("name",name);
            toppings.appendChild(
                <label for="garlic">garlic</label>);
            toppings.appendChild(
                <input type="checkbox" name="toppings" id="mushrooms" value="mushrooms" checked></input>);
            toppings.getElementById("mushrooms").setAttribute("name",name);
            toppings.appendChild(
                <label for="mushrooms">mushrooms</label>);
        }
        else
        {
            pizza.querySelector("input[class=sauce][value=tomato]").setAttribute(checked);
            //switch back to tomato
        }
        pizza.querySelector("input[class=price]").value = calculatePrice(pizza);
    });
}

function addAddToppingListener(item)
{
    item.addEventListener('click', function()
    {
        pizza = item.parentElement;
        var newtoppinginput = pizza.getElementById("newtoppinginput");
        pizza.insertBefore(
            <input type="checkbox" class="toppings" id="newtopping" value="newtopping" checked />
            , newtoppinginput
        );
        pizza.insertBefore(
            <label for="newtopping" id="newtoppinglabel">new topping</label>
            , newtoppinginput
        );
        var newtopping = pizza.getElementById("newtopping");
        var newtoppinglabel = pizza.getElementById("newtoppinglabel");
        var name = "toppings["+pizza.getElementById("number").value+"]";
        newtopping.name = name;
        newtopping.id = newtoppinginput.value;
        newtopping.value = newtoppinginput.value;
        newtoppinglabel.for = newtoppinginput.value;
        newtoppinglabel.innerHTML = newtoppinginput.value;
        newtoppinglabel.removeAttribute(id);
    });
}

function addRemoveListener(item)
{
    item.addEventListener('click', function()
        {
            pizza = item.parentElement;
            remove(pizza);
            pizzas = document.querySelectorAll("section[name=pizzas]");
            recalculatePizzaNumbers();
            calculateTotalPizzaNumber();
        });
}

function addQuantityListener(item)
{
    item.addEventListener('change', calculateTotalPizzaNumber());
}

function addPriceListener(item)
{
    item.addEventListener('change', calculateTotalPrice());
}

addpizza.addEventListener('click', function()
{
    //find the number of this new pizzas section
    var n = pizzas.Length;
    //create new pizza element
    var newpizza = (
        <section name="pizzas" id="pizza3">
            <h4>Pizza #3</h4>
            <input type="hidden" class="number" id="number" value="" />
            <h5>Base</h5>
            <input type="radio" class="base" id="custom" value="custom" checked></input>
            <label for="custom">Custom</label>
            <input type="radio" class="base" id="cheese" value="cheese"></input>
            <label for="cheese">Cheese Pizza (cheese, with tomato sauce)</label>
            <input type="radio" class="base" id="hawaiian" value="hawaiian"></input>
            <label for="">Hawaiian Pizza (cheese, ham, & pineapple, with tomato sauce)</label>
            <input type="radio" class="base" id="meat" value="meat"></input>
            <label for="meat">Meat Pizza (cheese, ham, pepperoni, & sausage, with tomato sauce)</label>
            <input type="radio" class="base" id="pesto" value="pesto"></input>
            <label for="pesto">Pesto Pizza (artichoke hearts, cheese, feta, garlic, & mushrooms, with pesto sauce</label>
            
            <h5>Size</h5>
            <input type="radio" class="size" id="small" value="small"></input>
            <label for="small">Small</label>
            <input type="radio" class="size" id="medium" value="medium" checked></input>
            <label for="medium">Medium</label>
            <input type="radio" class="size" id="large" value="large"></input>
            <label for="large">Large</label>

            <h5>Crust</h5>
            <input type="radio" class="crust" id="regular" value="regular" checked />
            <label for="regular">Regular</label>
            <input type="radio" class="crust" id="deep dish" value="deep dish" />
            <label for="deep dish">Deep Dish</label>
            <input type="radio" class="crust" id="stuffed" value="stuffed" />
            <label for="stuffed">Stuffed</label>
            <input type="radio" class="crust" id="thin" value="thin" />
            <label for="thin">Thin</label>
            
            <input type="checkbox" class="gluten free" id="gluten free" value="gluten free" />
            <label for="gluten free">gluten free</label>

            <h5>Sauce</h5>
            <input type="radio" class="sauce" id="alfredo" value="alfredo" />
            <label for="alfredo">Alfredo</label>
            <input type="radio" class="sauce" id="pesto" value="pesto" />
            <label for="pesto">Pesto</label>
            <input type="radio" class="sauce" id="tomato" value="tomato" checked />
            <label for="tomato">Tomato</label>

            <section id="currenttoppings">
                <h5>Toppings</h5>
            </section>
            <input class="addtopping" id="newtoppinginput" />
            <button name="addtopping">Add Topping!</button>

            <h5>Quantity</h5>
            <label for="quantity">How many of this pizza would you like?</label>
            <input type="number" class="quantity" min="0" max="15" value="1" />

            <label for="price">Price: $</label>
            <input type="number" class="price" id="price" step="0.01" value="@pizza.Price" readonly />

            <button name="removepizza">Remove Pizza</button>
        </section>
    );
    newpizza.getElementById("number").value = n;
    //Add the proper name to each input
    newpizza.querySelectorAll("input").forEach(input => function()
        {
            var name = input.class+"["+n+"]";
            input.setAttribute("name",name);
        }
    );
    //insert new pizza before the add button
    document.querySelector("form").insertBefore(newpizza, addpizza);
    addPizzaListeners();
    recalculatePizzaNumbers();
    calculateTotalPizzaNumber();
});

function removeAllChildNodes(parent)
{
    while (parent.firstChild)
    {
        parent.removeChild(parent.firstChild);
    }
}

function recalculatePizzaNumbers()
{
    var i = 1;
    var total;
    pizzas.forEach(element => {
        element.id = "pizza"+i;
        element.querySelector("h4").innerHTML = "Pizza #"+i;
        i++;
        total++;
        
    });
}

function calculateTotalPizzaNumber()
{
    var total = 0;
    pizzas.forEach(element => {
        total++;
        total *= element.querySelector("input[class=quantity]").value;
    });
    document.getElementById("numberofpizzas").value = total;
}

function calculatePrice(pizza)
{
    var price = 0;    //default in case the user unchecks the size checkbox
    if (pizza.querySelector("input[type=radio][class=size][value=small]").checked)
    {
        price = 5;
    }
    else if (pizza.querySelector("input[type=radio][class=size][value=medium]").checked)
    {
        price = 10;
    }
    else if (pizza.querySelector("input[type=radio][class=size][value=large]").checked)
    {
        price = 15;
    }

    var toppings = pizza.querySelectorAll("input[type=checkbox][class=toppings]")
    toppings.forEach(topping =>
        {
            if (topping.checked)
            {
                price += 0.5;
            }
        }
    );
    
    return price *= pizza.querySelector("input[class=quantity]").value;
}

function calculateTotalPrice()
{
    var totalprice = 0;
    pizzas.forEach(pizza => 
        {
            totalprice += calculatePrice(pizza);
        }
    );
    document.querySelector("input[name=totalprice]").value = totalprice;
}
