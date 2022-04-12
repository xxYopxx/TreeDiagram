# TreeDiagram

En el archivo de SepararSplices.xlsx hay 4 tabs.

El primer tab es la tabla de circuitos que es la lista de todos los cables que conforman el arnes. Para poder sacar los cables que pertenecen a un splice, la columna de SpliceMultL o SpliceMultR deben de empezar con las letras SPL. El nombre del splice se toma de la columna ConnIDL (si SpliceMutlL like 'SPL%') o ConnIDR (si SpliceMultR like 'SPL%')

Los splices de esta tabla son: RG-S9, RG-S8, RG-S5, RG-S14, RG-S6, RG-S11, RG-S4, RG-S7, RG-S2, RG-S10, RG-S13, RG-S1, RG-S12 y RG-S3.

Solamente existen 2 grupos de splices que estan conectados entre si, el primer grupo son los splices RG-S5 y RG-S14, el segundo serian los splices RG-S6 y RG-S11. El primer grupo esta marcado en amarillo y el segundo en verde en el tab de Cables Splices.

El primer grupo deberia de verse asi:

![image](https://user-images.githubusercontent.com/40281584/162865806-f28fed42-1dcb-4997-bf0c-60c6ffa26818.png)


En el tab de Esquematico1 se muestra la conexion del primer grupo.

Para saber si el cable va al lado izquierdo o derecho, se toma en cuenta la columna CavL o CavR. Si en la columna SpliceMultL empieza con SPL se toma el valor de la columna CavL, si existe en SpliceMultR se toma el valor de la columna CavR. Si el valor de CavL o CavR es 1 el cable va por el lado izquierdo, si es 2 debe de ir por el derecho.

![image](https://user-images.githubusercontent.com/40281584/162865656-0948c95a-a4b0-4bf7-8309-d0713afb0f0e.png)

