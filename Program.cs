// See https://aka.ms/new-console-template for more information
using System;

namespace TP
{
    public enum Kelurahan { Batununggal, Kujangsari, Mengger, Wates, Cijaura, Jatisari, Margasari, Sekejati, Kebonwaru, Maleer, Samoja }
    public enum DoorMachineState { Terkunci, Terbuka };
    public enum Trigger { KunciPintu, BukaPintu };
    class KodePos
    {
        public static int getKodePos(Kelurahan kelurahan)
        {
            int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            return kodePos[(int)kelurahan];
        }
    }



    class DoorMachine
    {
        
        public DoorMachineState currentState;



        class Transition
        {
            public DoorMachineState prevState;
            public DoorMachineState nextState;
            public Trigger trigger;

            public Transition(DoorMachineState prevState, DoorMachineState nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        Transition[] transitions =
        {
            new Transition(DoorMachineState.Terbuka, DoorMachineState.Terkunci, Trigger.KunciPintu),
            new Transition(DoorMachineState.Terkunci, DoorMachineState.Terbuka, Trigger.BukaPintu)
        };

        public DoorMachineState getNextState(DoorMachineState prevState, Trigger trigger)
        {
            DoorMachineState nextState = prevState;

            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
                {
                    nextState = transitions[i].nextState;
                }
            }

            return nextState;
        }

        public void activateTrigger(Trigger trigger)
        {
            DoorMachineState nextState = getNextState(this.currentState, trigger);
            currentState = nextState;

            if (currentState == DoorMachineState.Terkunci)
            {
                Console.WriteLine("Terkunci");
            } else
            {
                Console.WriteLine("Terbuka");
            }
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            DoorMachine pintu = new();

            Console.WriteLine("Contoh mengakses kode pos kelurahan Cijaura");
            Console.WriteLine(KodePos.getKodePos(Kelurahan.Cijaura));

            Console.WriteLine("Contoh menggunakan class DoorMachine");
            pintu.activateTrigger(Trigger.KunciPintu);
            pintu.activateTrigger(Trigger.BukaPintu);

        }
    }

}