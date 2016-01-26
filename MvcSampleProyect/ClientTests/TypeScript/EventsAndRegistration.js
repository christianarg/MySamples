var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var EventsAndRegistration;
(function (EventsAndRegistration) {
    var Event = (function () {
        function Event() {
        }
        return Event;
    })();
    EventsAndRegistration.Event = Event;
    var RocketLaunchedEvent = (function (_super) {
        __extends(RocketLaunchedEvent, _super);
        function RocketLaunchedEvent() {
            _super.apply(this, arguments);
        }
        RocketLaunchedEvent.eventName = 'EventsAndRegistration.RocketLaunchedEvent';
        return RocketLaunchedEvent;
    })(Event);
    EventsAndRegistration.RocketLaunchedEvent = RocketLaunchedEvent;
})(EventsAndRegistration || (EventsAndRegistration = {}));
//# sourceMappingURL=EventsAndRegistration.js.map