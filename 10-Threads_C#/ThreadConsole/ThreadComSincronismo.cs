﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadConsole
{
    class ThreadComSincronismo
    {

        private static int x = 0;

        private static Object locker = new Object();

        private static void Executa(){
            for (int i = 0; i < 100; i++){
                lock (locker)   // garante o sincronismo ao acessar a variavel compartilhada
                {
                    Console.Write("Thread: " + Thread.GetCurrentProcessorId().ToString() + ": ");
                    Console.WriteLine("Acessando memória compartilhada: " + x);
                    // Thread.Sleep(1000);
                    x = x + 1;
                }
            }
        }

        public static void Inicia(){
            
            Thread t1 = new Thread(Executa);
            Thread t2 = new Thread(Executa);
            
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Valor x=" + x);
        }
    }
}
