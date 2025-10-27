Proyecto: Demo del Ciclo de Vida de Dependencias en .NET

En este proyecto, exploré cómo funcionan los tres ciclos de vida de Inyección de Dependencias (DI) en ASP.NET Core.
Creé un servicio de gestión de pedidos (ServicioPedidos) para observar en la práctica cómo influye el ciclo de vida en el comportamiento de la aplicación,
especialmente en cómo se mantiene (o no) una lista de pedidos en memoria.

Para implementar cada tipo de servicio, mi estrategia fue usar "interfaces marcadoras". Primero, creé la interfaz principal IServicioPedidos. 
Luego, creé tres interfaces nuevas que heredaban de la base: IServicioPedidosTransitorio, IServicioPedidosDelimitado y IServicioPedidosSingleton. 
Hice que mi clase ServicioPedidos implementara estas tres interfaces. Finalmente, en el archivo Program.cs, 
registré cada interfaz marcadora con su ciclo de vida correspondiente, pero todas apuntando a la única clase ServicioPedidos.

Observé el comportamiento en las pruebas usando Postman.

Para el Transitorio (Transient), cada vez que llamaba a un endpoint, el ID de instancia era siempre diferente. 
Si agregaba un pedido con POST y luego hacía GET, la lista volvía vacía. Esto es porque se crea una instancia totalmente nueva para cada solicitud.

Para el Delimitado (Scoped), el comportamiento fue similar. Un POST y un GET generaban IDs diferentes porque eran solicitudes separadas,
y la lista también aparecía vacía en el GET. La diferencia es que se crea una nueva instancia por cada solicitud HTTP, pero se reutilizaría la misma si
la necesitara en varios lugares dentro de esa misma solicitud.

Para el Singleton, el ID de instancia fue siempre el mismo, sin importar cuántas veces llamara a POST o GET. Si agregaba un pedido con POST,
la llamada GET siguiente me mostraba ese pedido. Si agregaba otro, el GET mostraba ambos. Esto es porque existe una única instancia para toda la aplicación y 
mantiene su estado.

Así es como visualizo los ciclos de vida. El Transitorio crea una instancia nueva cada vez que se pide. El Delimitado crea una instancia nueva por 
solicitud HTTP y se reutiliza solo dentro de esa solicitud. El Singleton crea una sola instancia para toda la vida de la aplicación.

En escenarios reales, yo usaría Transitorio para servicios ligeros y sin estado, como una calculadora o un validador.

Usaría Delimitado la gran mayoría del tiempo, especialmente para el DbContext de Entity Framework Core, donde necesito que todas las operaciones de
una solicitud compartan la misma transacción.

Usaría Singleton solo cuando necesito un estado global compartido, como un servicio de Caching, o para servicios costosos de crear.
