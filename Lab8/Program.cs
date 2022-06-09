namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            //тут могла быть реализация ручного ввода//
            var x = randomCreateMatrix();
            randomInitializeMatrix(x);
            PrintMatrix(x);
            var y = randomCreateMatrix();
            randomInitializeMatrix(y);
            PrintMatrix(y);

            double[,] sumXY = matrixSumm(x, y);
            if (sumXY != null) PrintMatrix(sumXY);

            double[,] subtractXY = matrixSubtraction(x, y);
            if (subtractXY != null) PrintMatrix(subtractXY);

            double[,] multXY = matrixMultiplication(x, y);
            if(multXY != null) PrintMatrix(multXY);
        }

        protected static double[,] randomCreateMatrix()
        {
            Random r = new Random();
            double[,] matrix = new double[r.Next(1, 10), r.Next(1, 10)];
            return matrix;
        }

        protected static void randomInitializeMatrix(double[,] matrix)
        {
            Random r = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(-100, 100) / 10.0;
                }
            }
        }
        protected static void PrintMatrix(double[,] matrix)
        {
            Console.WriteLine("Матрица ");
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}", matrix[i, j].ToString().PadLeft(7));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
        }

        public static double[,] matrixSumm(double[,] matrix1, double[,] matrix2)
        {
            if ((matrix1.GetLength(0) != matrix2.GetLength(0)) || (matrix1.GetLength(1) != matrix2.GetLength(1)))
            {
                Console.WriteLine("Матрицы не равны");
                return null;
            }
            else
            {
                double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(0); j++)
                    {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return result;
            }

        }

        public static double[,] matrixSubtraction(double[,] matrix1, double[,] matrix2)
        {
            if ((matrix1.GetLength(0) != matrix2.GetLength(0)) || (matrix1.GetLength(1) != matrix2.GetLength(1)))
            {
                Console.WriteLine("Матрицы не равны");
                return null;
            }
            else
            {
                double[,] result = new double[matrix1.GetLength(0),matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(0); j++)
                    {
                        result[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                return result;
            }
        }

        public static double[,] matrixMultiplication(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("матрицы нельза перемножить");
                return null;
            }
            double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }
    }
}