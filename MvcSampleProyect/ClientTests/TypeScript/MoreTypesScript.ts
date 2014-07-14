module MoreTypescript{
    class MyBaseClass{
        public myBaseMethod() {

        }
    }

    class MyOtherBaseClass {
        public myOtherBaseMethod() {

        }
    }

    class MyUltraClass extends MyBaseClass  {

    }
} 



interface IMondongo {
    pepito(): void;
}

interface IMondongo {
    pablito(): void;
}

var kito: IMondongo;

class Mondongo implements IMondongo {
    public pepito() { }
    public pablito() { }
}