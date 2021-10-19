using System;

namespace tictac
{
    class Program
    {
        const char firstPlayer = 'X';
        const char secondPlayer = 'O';
        const char emptyField = ' ';
        static int turn = 0;
        static bool findWinner = false;
        static void Main(string[] args)
        {
            char[,] fields = {{emptyField, emptyField, emptyField},
                             {emptyField, emptyField, emptyField},
                             {emptyField, emptyField, emptyField}};
            do{
                writeField(fields);
                char answ = status(fields);
                if(findWinner == true){
                    Console.WriteLine($"{answ} is winner");
                }
                if(answ == '/'){
                    findWinner = true;
                    Console.WriteLine("Draw");
                }
                makeTurn(fields);
            }while(turn <= 9 && findWinner != true);
        }
        static void writeField(char[,] fild){
            for(int i = 0; i < fild.GetLength(0); i++){
                for(int j = 0; j < fild.GetLength(1); j++){
                    Console.Write(j < 2 ? fild[i,j] + "|" : fild[i,j]);
                }
                Console.Write(i < 2 ? "\n" + new string ('-', 5) + "\n" : "\n");
            }
        }
        static char status(char[,] fild){
            int noEmpty = 0;
            if(fild[0,0] != emptyField && fild[1,1] == fild[2,2] && fild[0,0] == fild[1,1]){
                    findWinner = true;
                    return fild[0,0];
                }
            if(fild[0,2] != emptyField && fild[1,1] == fild[2,0] && fild[0,2] == fild[1,1]){
                    findWinner = true;
                    return fild[0,2];
                }
            for(int i = 0; i < fild.GetLength(0); i++){
                if(fild[i,0] != emptyField && fild[i,1] == fild[i,2] && fild[i,0] == fild[i,1]){
                    findWinner = true;
                    return fild[i,0];
                } 
                if(fild[0,i] != emptyField && fild[1,i] == fild[2,i] && fild[0,i] == fild[1,i]){
                    findWinner = true;
                    return fild[0,i];
                }
                for(int j = 0; j < fild.GetLength(0); j++){
                    if(fild[i,j] != emptyField){
                        noEmpty++;
                    } else {
                        j += 2;
                    }
                }
            }
            if(noEmpty != 9 && findWinner != true) {
                Console.WriteLine(turn % 2 == 0 ? "X your turn" : "O your turn");
            }
            if(noEmpty == 9){
                return '/';
            } else {
                return '*';
            }
        }
        static char makeTurn(char[,] fild){
            int rt = turn;
            turn++;
            string[] takeCord = Console.ReadLine().Split(" ");
            if(takeCord.GetLength(0) == 2){
                int x = Convert.ToInt32(takeCord[0]) - 1;
                int y = Convert.ToInt32(takeCord[1]) - 1;
                if(fild[x,y] == emptyField){
                    return rt % 2 == 0 ? fild[x,y] = firstPlayer : fild[x,y] = secondPlayer;
                } else {
                    if(findWinner != true){
                        turn--;
                        Console.WriteLine("This field is busy");
                        return makeTurn(fild);
                    } else { return '#';}
                }
            } else {
                if(findWinner != true){
                    turn--;
                    Console.WriteLine("Invalid value");
                    return makeTurn(fild);
                } else { return '#';}
            }
        }
    }
}
