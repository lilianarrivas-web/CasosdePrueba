using System;
using System.Collections.Generic;

public static class Pruebas
{
    public static void Ejecutar(Func<double, int, double> calcularSalario)
    {
        var casosDePrueba = new List<(string Id, double Horas, int Categoria, double SalarioEsperado, bool EsperaError)>
        {
            // Caminos Básicos y Condiciones
            ("CP-01", -5, 1, 0, true),
            ("CP-02", 30, 9, 0, true),
            ("CP-03", 35, 1, 420000, false),
            ("CP-04", 45, 1, 555000, false),
            ("CP-05", 50, 2, 892500, false),
            ("CP-06", 42, 3, 935000, false),

            // Particiones de Equivalencia
            ("CP-07", 20, 1, 240000, false),
            ("CP-08", 48, 2, 850000, false),
            ("CP-09", -10, 1, 0, true),
            ("CP-10", 40, 1, 480000, false),
            ("CP-11", 40, 2, 680000, false),
            ("CP-12", 40, 3, 880000, false),
            ("CP-13", 40, 8, 0, true),

            // Valores Límite
            ("CP-14", -1, 1, 0, true),
            ("CP-15", 0, 1, 0, false),
            ("CP-16", 1, 1, 12000, false),
            ("CP-17", 39, 1, 468000, false),
            ("CP-18", 40, 1, 480000, false),
            ("CP-19", 41, 1, 495000, false),
            ("CP-20", 20, 0, 0, true),
            ("CP-21", 20, 3, 440000, false),
            ("CP-22", 20, 4, 0, true),
            
            // Pruebas adicionales de cobertura de categorías
            ("CP-23", 41, 2, 701250, false),
            ("CP-24", 41, 3, 907500, false),
            ("CP-25", 0, 2, 0, false),
            ("CP-26", 0, 3, 0, false),
            ("CP-27", 60, 1, 780000, false),
            ("CP-28", 60, 2, 1105000, false),
            ("CP-29", 60, 3, 1430000, false),
            ("CP-30", -0.5, 2, 0, true),
            ("CP-31", 39, 2, 663000, false),
            ("CP-32", 39, 3, 858000, false),
            ("CP-33", 40.5, 1, 487500, false),
            ("CP-34", 100, 2, 1955000, false),
            ("CP-35", 10, -1, 0, true)
        };

        Console.WriteLine("\n Ejecucion de pruebas");
        Console.WriteLine(string.Format("{0,-8} - {1,-6} - {2,-4} - {3,-12} - {4,-15} - {5,-8}", "ID", "HORAS", "CAT", "ESPERADO", "OBTENIDO", "ESTADO"));

        int pasadas = 0;

        foreach (var c in casosDePrueba)
        {
            try
            {
                double obtenido = calcularSalario(c.Horas, c.Categoria);
                if (!c.EsperaError && Math.Abs(obtenido - c.SalarioEsperado) < 0.01)
                {
                    Console.WriteLine(string.Format("{0,-8} - {1,-6} - {2,-4} - ${3,-11:N0} - ${4,-14:N0} - [PASÓ]", c.Id, c.Horas, c.Categoria, c.SalarioEsperado, obtenido));
                    pasadas++;
                }
                else
                {
                    Console.WriteLine(string.Format("{0,-8} - {1,-6} - {2,-4} - ${3,-11:N0} - ${4,-14:N0} - [FALLÓ]", c.Id, c.Horas, c.Categoria, c.SalarioEsperado, obtenido));
                }
            }
            catch (ArgumentException)
            {
                if (c.EsperaError)
                {
                    Console.WriteLine(string.Format("{0,-8} - {1,-6} - {2,-4} - {3,-12} - {4,-15} - [PASÓ]", c.Id, c.Horas, c.Categoria, "Error/Excep", "Error controlado"));
                    pasadas++;
                }
                else
                {
                    Console.WriteLine(string.Format("{0,-8} - {1,-6} - {2,-4} - {3,-12} - {4,-15} - [FALLÓ]", c.Id, c.Horas, c.Categoria, "Salario", "Error inesperado"));
                }
            }
        }

        Console.WriteLine($"Total: {casosDePrueba.Count} - Aprobadas: {pasadas} - Fallidas: {casosDePrueba.Count - pasadas}");
    }
}