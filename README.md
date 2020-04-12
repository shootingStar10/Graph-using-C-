# Graph-using-CSharp

#### Mother Vertex:
  A mother vertex in a graph G = (V,E) is a vertex v such that all other vertices in G can be reached by a path from v.
  To find the mother vertex in a graph do DFS and find the last finished vertex v. Do another DFS with this vertex v & check if this vertex covers all the vertices or not. 
