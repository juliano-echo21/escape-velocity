
# 🌌 escape-velocity

## 👩‍🚀 Integrantes

- Julián Ramirez Diaz
- Maria Fernanda Cala
- Julián David Rincón Orjuela  
---

## 🧭 Storytelling del Proyecto

### Narrativa del juego

Eres un astronauta que ha sufrido un accidente espacial durante una misión. En el caos, has sido expulsado de tu nave y has atravesado accidentalmente un agujero de gusano, emergiendo en un sistema solar desconocido y hostil. 

Tu misión es simple, pero urgente: **sobrevive, explora planetas para recolectar recursos y encuentra el agujero de gusano de regreso antes de que se te agote el oxígeno.**

Cada planeta representa un escenario visualmente único, con desafíos que te forzarán a decidir entre arriesgarte por recursos o buscar una salida rápida. ¿Te atreverás a explorar más o jugarás seguro?

### Posibles escenarios de uso y experiencia

- Exploración de planetas con gravedad, terrenos y obstáculos únicos.
- Mecánicas de recolección de recursos que impactan el tiempo de oxígeno disponible.
- Sistema de navegación hacia el agujero de gusano.
- UI inmersiva con indicadores de oxígeno y radar de cercanía.

### Objetivos del sistema

- **Visual**: Diseñar entornos espaciales inmersivos y estilizados.
- **Educativo**: Introducir nociones básicas de supervivencia espacial y manejo de recursos.
- **Tecnológico**: Demostrar el uso de Unity para creación de mundos 3D, físicas y animaciones interactivas.
- **Narrativo**: Generar tensión y curiosidad a través de la historia y decisiones del jugador.

---

## 🧾 Levantamiento de Requerimientos

### Requerimientos funcionales

- Movimiento en primera o tercera persona.
- Exploración libre de planetas con diferentes terrenos.
- Gestión de oxígeno y tiempo límite.
- Sistema de recolección de recursos (opcional).
- Animación de entrada/salida por agujero de gusano.
- UI dinámica para indicadores de estado.

### Requerimientos no funcionales

- Compatibilidad con Windows.
- Accesibilidad: UI contrastada, controles configurables.
- Compatible con teclado y mouse estándar, sin necesidad de hardware adicional.
- Uso eficiente de memoria.
- El código debe estar modularizado y seguir buenas prácticas.

### Restricciones

- Limitaciones gráficas debido al rendimiento.
- No se utilizarán datos reales o personales.

### Supuestos de diseño
- Jugado en entorno individual, con teclado y ratón.
---

## 🧠 Requerimientos Técnicos y Tecnológicos

- **Lenguaje de programación:** C#
- **Motor de juego:** Unity 2022.x
- **Bibliotecas:** RigidBody 3D, Sistema de particulas de Unity
- **Protocolo de comunicación:** N/A (juego local)
- **Arquitectura:** Modular basada en componentes de Unity (scripting + prefabs + escenas)

---

## 🗂️ Diagramas y Arquitectura

### Diagrama general del sistema

- Controlador de jugador
- Sistema de oxígeno
- Sistema de transición de escenas
- Módulo de UI
- Controlador de planeta/escenario

### Flujo de usuario

1. Intro animada
2. Despertar en un nuevo planeta
3. Exploración / recolección de recursos
4. Buscar y encontrar el agujero de gusano
5. Transición de regreso / Game Over

### Riesgos técnicos identificados

- Implementación de físicas planetarias no realistas
- Administración del rendimiento en escenarios amplios

---

## 📊 Mockups o Prototipos

- Prototipo inicial de UI creado en Figma
- Bocetos de los planetas y HUD (Heads-Up Display)
- Estilo visual: tonos oscuros, luz tenue, elementos retrofuturistas
- Iconografía minimalista, sin texto cuando sea posible

> Las imágenes estarán disponibles en la carpeta `/Docs/Mockups` y como presentación en Figma.

---

## ✅ Estado Actual

- Diseño narrativo validado
- Mockups iniciales completados
- Arquitectura del juego definida
- Repositorio configurado con estructura base

---

¡Prepárate para embarcarte en una aventura cósmica donde cada segundo y cada decisión cuenta! 🚀
