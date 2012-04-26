(function() {

  $(function() {
    var DeliveryRouter, app;
    DeliveryRouter = Backbone.Router.extend({
      routes: {
        "": "list"
      },
      list: function() {
        this.deliveryList = new DeliveryCollection();
        this.deliveryListView = new DeliveryListView({
          model: this.deliveryList
        });
        return this.deliveryList.fetch();
      }
    });
    app = new DeliveryRouter();
    return Backbone.history.start();
  });

}).call(this);
