$ -> 
    # Start app
    Backbone.history.start()


## Models ##
window.Delivery = Backbone.Model.extend()

window.DeliveryCollection = Backbone.Collection.extend
    model: Delivery
    url: '../../api/deliveries'


## Views ##
window.DeliveryListView = Backbone.View.extend
    initialize: ->
        @model.on 'reset', @render, @

    render: -> 
        $.each @model.models, (index, delivery) => 
            $(@el).append new DeliveryListItemView({model: delivery}).render().el


window.DeliveryListItemView = Backbone.View.extend
    tagName: 'li'

    template: _.template $('#tplWineListItem').html()

    render: -> 
        $(@el).html @template @model.toJSON()
        @