myApp.service('basketService', function ()
{

    basket = new Array();
    baskettotal = 0;

    this.getBasket = function ()
    {
        return basket;
    }

    this.getTotal = function ()
    {
        return Math.round(baskettotal);
    }

    function money_multiply(a, b)
    {
        var log_10 = function (c) { return Math.log(c) / Math.log(10); },
            ten_e = function (d) { return Math.pow(10, d); },
            pow_10 = -Math.floor(Math.min(log_10(a), log_10(b))) + 1;
        return ((a * ten_e(pow_10)) * (b * ten_e(pow_10))) / ten_e(pow_10 * 2);
    }

    this.addToBasket = function (item, quantity)
    {
        var result = $.grep(basket, function (e) { return e.product.Code == item.Code })
        if (result.length == 0)
        {
            var i = new Object();
            i.product = item;
            i.Quantity = quantity;
            i.Price = money_multiply (quantity , Number(item.Price.replace(/[^0-9\.]+/g, "")));
            basket.push(i);
            
        }
        else
        {
            result[0].Quantity++;
            result[0].Price =money_multiply( result[0].Quantity , Number(result[0].product.Price.replace(/[^0-9\.]+/g, "")));
        }
        baskettotal = 0
        for (var i = 0; i < basket.length; i++)
        {
            baskettotal += basket[i].Price
        }


    }

   
});