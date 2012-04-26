(function() {

  $(function() {
    return Backbone.history.start();
  });

  window.Delivery = Backbone.Model.extend();

  window.DeliveryCollection = Backbone.Collection.extend({
    model: Delivery,
    url: '../../api/deliveries'
  });

  window.DeliveryListView = Backbone.View.extend({
    initialize: function() {
      return this.model.on('reset', this.render, this);
    },
    render: function() {
      var _this = this;
      return $.each(this.model.models, function(index, delivery) {
        return $(_this.el).append(new DeliveryListItemView({
          model: delivery
        }).render().el);
      });
    }
  });

  window.DeliveryListItemView = Backbone.View.extend({
    tagName: 'li',
    template: _.template($('#tplWineListItem').html()),
    render: function() {
      $(this.el).html(this.template(this.model.toJSON()));
      return this;
    }
  });

}).call(this);
