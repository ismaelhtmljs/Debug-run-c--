#include <iostream>
#include <ctime>
using namespace std;

int main() {
    int opcion;

    do {
        // Mostrar menú
        cout << "Seleccione una opcion:\n";
        cout << "1. Saludar\n";
        cout << "2. Mostrar la fecha y hora\n";
        cout << "3. Salir\n";
        cout << "Opcion: ";
        cin >> opcion;

        // Lógica basada en la opción seleccionada
        switch (opcion) {
            case 1:
                cout << "¡Hola, bienvenido al programa!" << endl;
                break;
            case 2: {
                // Mostrar la fecha y hora actual (se asume que el sistema tiene configurada la hora)
                time_t now = time(0);
                char* dt = ctime(&now);
                cout << "Fecha y hora actual: " << dt << endl;
                break;
            }
            case 3:
                cout << "Saliendo del programa..." << endl;
                break;
            default:
                cout << "Opción inválida, por favor intente de nuevo." << endl;
                break;
        }
    } while (opcion != 3);  // El programa sigue hasta que el usuario elige la opción 3

    return 0;
}
