# FijaTEA
Sistema de estudio de fijación basado en videojuegos orientado a TEA. 

FijaTEA incluye:
- Proyecto Unity de prueba de fijación en la carpeta "FijaTEA".
- Proyecto Unity de prueba preeliminar a Fijatea llamado "Atención, Ascensor".
- Ejecutables de ambos proyectos para la plataforma Windows, así como una versión de FijaTEA exportada a Android. 

# Tabla de contenidos 

1. [Importar proyecto Unity mediante Unity Hub](#importar-proyecto-unity-mediante-unity-hub)
2. [Replicación de experimentos](#replicación-de-experimentos)
3. [Notas de versión](#notas-de-versión)
4. [Copyright](#copyright)



## Importar proyecto Unity mediante Unity Hub
**Para realiziar este método de importación es necesario tener instalado Unity y Unity Hub. Otros métodos tambien son posibles.*

Primero descargamos la carpeta con el nombre del proyecto deseado, ya sea Fijatea o Atención, Ascensor.  

Una vez descargado debe de ser descomprimido en caso de estarlo.  

Dentro de Unity hub seleccionamos "ADD" y elegimos la carpeta descargada; una vez aceptemos el programa se encargará de completar la instalación.


## Replicación de experimentos

Para realizar pruebas basadas en fijación planificadas es requerido el uso de un dispositivo de eye tracking preferiblemente remoto y software de análisis compatible, en el caso de este experimento se ha usado el dispositivo Gazepoint GP3 con su suite de análisis.
Alternativas interesantes puede ser hardware de Tobii junto con el programa Ogama.

Se recomienda hacer la prueba "Atención, Ascensor" previamente a la de FijaTEA para identificar si el usuario será capaz de llevar a cabo el  estudio de fijación o debe de ser dirigido a la actividad en formato móvil.
Para ello solo es necesario abrir el ejecutable de esta puebla y dejar interactuar al usuario. En el caso de que este experimente dificultades notorias se podrá asistir al usuario, si con este apoyo no es capaz de completar el tercer nivel no debería ser expuesto a las pruebas en ordenador.

En el caso de que sí pase los 3 primeres niveles se procede a realizar el estudio de fijación. Para ello primero hace falta conectar el dispositivo hardware de eye tracking al ordenador y abrir la suite de análisis de fijación seleccionada.
Se deberá seguir el procedimiento propio de calibración con cada usuario, asegurando que los ojos del usuario quedan dentro del rango de acción del dispositivo.
Tras ello comenzará la grabación de la actividad, lanzará el ejecutable juego y se le entregará al usuario un ratón como medio de interacción.

La grabación resultante de esta actividad ha de ser examinada, preferiblemente mediante el estudio de mapas de calor para identificar zonas ignoradas así como uso de AOIs para conocer cuanta atención le presta a los elementos relevantes.

En el caso de uso de la versión móvil, dada la incompatibilidad con el sistema de eye tracking  esta no actua como prueba sino como actividad de refuerzo independiente. 


## Notas de versión

Los programas han sido probados en dispositivos con ratio de panatalla 16:9.

Es posible encontrar problemas visuales con otros ratios no probados, en ese caso se recomienda establecer el ratio del dispositivo a 16:9. 


## Copyright
MIT License

Copyright (c) 2021 José Luis de la Rosa Morillas

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
