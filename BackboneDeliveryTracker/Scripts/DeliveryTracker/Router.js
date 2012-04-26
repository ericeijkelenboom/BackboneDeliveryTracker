(function() {
  var DeliveryRouter;

  DeliveryRouter = Backbone.Router.extend({
    routes: {
      "": "list"
    },
    list: function() {
      this.deliveryList = new DeliveryCollection();
      this.deliveryListView = new DeliveryListView({
        model: this.deliveryList,
        el: $('#deliveryList')
      });
      return this.deliveryList.fetch();
    }
  });

  window.router = new DeliveryRouter();

}).call(this);
