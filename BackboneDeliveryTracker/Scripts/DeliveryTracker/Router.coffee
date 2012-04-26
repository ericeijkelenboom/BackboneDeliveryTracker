DeliveryRouter = Backbone.Router.extend
    routes: {
        "": "list"
    }

    list: -> 
        @deliveryList = new DeliveryCollection()
        @deliveryListView = new DeliveryListView({model: @deliveryList, el: $ '#deliveryList'})
        @deliveryList.fetch()

window.router = new DeliveryRouter()