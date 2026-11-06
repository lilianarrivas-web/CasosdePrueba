Pruebas.Ejecutar(CalcularSalario);

double horasTrabajadas = 60;
int categoriaEmpleado = 2;

double salarioFinal = CalcularSalario(horasTrabajadas, categoriaEmpleado);

Console.WriteLine($"Horas trabajadas: {horasTrabajadas}");
Console.WriteLine($"Categoría: {categoriaEmpleado}");
Console.WriteLine($"Salario total a pagar: ${salarioFinal:N0}");

double CalcularSalario(double horas, int categoria)
{
    // validamos las horas negativas con esta condicional
    if (horas < 0)
        throw new ArgumentException("Las horas trabajadas no pueden ser negativas.");

    // determinamos la tarifa según categoría
    double tarifa;
    switch (categoria)
    {
        case 1:
            tarifa = 12000;
            break;
        case 2:
            tarifa = 17000;
            break;
        case 3:
            tarifa = 22000;
            break;
        default:
            throw new ArgumentException("Categoría no válida. Debe ser 1, 2 o 3.");
    }

    // aca se calcula el salario considerando horas extras
    if (horas <= 40)
    {
        return horas * tarifa;
    }
    else
    {
        double horasExtras = horas - 40;
        double pagoNormal = 40 * tarifa;
        double pagoExtras = horasExtras * (tarifa * 1.25);
        return pagoNormal + pagoExtras;
    }
}