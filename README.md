# Furnitwister

Juego de Plataformas en 2D. Llega al final de los niveles mientras el tornado te avasalla con sillas y mesas que tendrás que esquivar. Contarás con 5 vidas por nivel y cada nivel será peor que el anterior. ¿Conseguirás llegar al final? (Actualmente en la Beta 0.1 solo se cuenta con dos niveles)

## Ejecutar

Para ejecutar el juego ir a la carpeta builds/Windows/x64 y ejecutar el fichero "Furnitwister.exe"

## Controles

* Movimiento a izquierda y derecha: A y D respectivamente
* Saltar: Mantener Espacio para controlar el tiempo de salto hasta un máximo (Se puede mover horizontalmente durante el salto)
* Encogerse: El personaje puede encogerse pulsado Left Shift o S. Si se mueve con A o D o salta mientras está encogido volverá a su tamaño normal.
* Los tubos que encontrarás como palancas en el mapa, te darán un boost de movimiento, pero ten cuidado, podría no salir a tu favor.

## Datos de desarrollo

* Dos niveles totalmente jugables con dos fondos parallax distintos.
* Personaje 2D con animaciones de Idle, Caminar, Saltar, Daño y Muerte.
* HUD para la vida del personaje con colores distintos según gradiente.
* Sistema de Pooling para un Spawn de obstáculos más eficiente.
* Dificultad progresiva. Cada nivel será más difícil que el anterior, reduciendo el tiempo de spawn de obstáculos y aumentando la velocidad de los mismos, así como la longitud del mapa.
* Sistema de salto con control total por parte del jugador del tiempo que quiere estar en el aire, así como del propio movimiento en el aire.
* Control de cámara con Cinemachine.
