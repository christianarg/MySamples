 

module EventsAndRegistration {

    export class Event {
        public static eventName;

       
    }

    export class RocketLaunchedEvent extends Event {
        public static eventName = 'EventsAndRegistration.RocketLaunchedEvent';
    }
}