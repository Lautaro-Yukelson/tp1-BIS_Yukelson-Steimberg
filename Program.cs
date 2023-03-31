List<Dictionary<string, int>> cursos = new List<Dictionary<string, int>>();
int cont = 0;
menu(ref cursos, cont);

void menu(ref List<Dictionary<string, int>> cursos, int cont){
    Console.Clear();
    Console.WriteLine(".:Bienvenido a nuestro sistema:.");
    Console.WriteLine("********************************");
    Console.WriteLine("*Eliga una opción para continuar*");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1. Ingrese los importes de un curso");
    Console.WriteLine("2. Ver estadísticas");
    Console.WriteLine("3. Salir");

    int opcion = int.Parse(Console.ReadLine());
    Console.Clear();

    while (opcion != 1 && opcion != 2 && opcion != 3){
        Console.WriteLine("La opción seleccionada no existe");
        Console.WriteLine("Porfavor, ingrese la opcion nuevamente");
        opcion = int.Parse(Console.ReadLine());
    }

    switch (opcion){
    case 1:
        crearCurso(ref cursos);
        cont++;
        ingresarDatos(ref cursos);
        menu(ref cursos, cont);
        break;
    case 2:
        if (cont >= 1){
            mostrarEstadisticas(ref cursos);
            menu(ref cursos, cont);
        } else {
            Console.WriteLine("Lo siento, todavia no has ingresado ningun curso :)");
        }
        break;
    case 3:
        Console.WriteLine("Saliendo del programa...");
        break;
    }
}

void crearCurso(ref List<Dictionary<string, int>> cursos){
    Console.WriteLine("¿Cuantos cursos va a ingresar?");
    int n = int.Parse(Console.ReadLine());
    Console.Clear();
    for (int i = 0; i<n; i++){
        Console.WriteLine($"Ingrese el curso numero {i+1}");
        Console.WriteLine("1. 1ero");
        Console.WriteLine("2. 2do");
        Console.WriteLine("Etc...");
        int curso = int.Parse(Console.ReadLine());
        Console.WriteLine("***************************");
        Console.WriteLine("Ahora cuantos son en total");
        int cantidad = int.Parse(Console.ReadLine());


        
        Dictionary<string, int> diccionario = new Dictionary<string, int>();
        diccionario.Add("curso", curso);
        diccionario.Add("cantidad", cantidad);
        diccionario.Add("plata", 0);
        cursos.Add(diccionario);
        Console.Clear();
    }
}

void ingresarDatos(ref List<Dictionary<string,int>> cursos){
    for (int i = 0; i<cursos.Count; i++){
        Console.WriteLine("**Vamos con el curso número " + cursos[i]["curso"] + "**");
        for (int x = 0; x<cursos[i]["cantidad"]; x++){
            Console.WriteLine($"Ingrese lo que puso el alumno numero {x+1}");
            cursos[i]["plata"] += int.Parse(Console.ReadLine());
        }
        Console.Clear();
    }
}

void mostrarEstadisticas(ref List<Dictionary<string, int>> cursos){
    int cursoMayorPlata = -1, cursoMayor = 0, recaudacionCursos = 0;
    for (int i = 0; i<cursos.Count; i++){
        if (cursos[i]["plata"] > cursoMayorPlata){
            cursoMayorPlata = cursos[i]["plata"];
            cursoMayor = cursos[i]["curso"];
        } 
        recaudacionCursos += cursos[i]["plata"];
    }
    Console.WriteLine("El curso que mas plata recaudo es el número " + cursoMayor + " con un total de $" + cursoMayorPlata + " pesos");
    Console.WriteLine("El promedio de plata regalado por todos los cursos es: $" + recaudacionCursos/cursos.Count + " pesos");
    Console.WriteLine("La recaudación total entre todos los cursos es de $" + recaudacionCursos + " pesos");
    Console.WriteLine("Y por ultimo la cantidad de cursos que participaron en el regalo fueron " + cursos.Count);
    Console.ReadKey();
}