%Structs
%nume=id(type1,type2...)
%Ex:
%complex=c(real,real).
%lista=complex*


%EX1:
%F={F1,F2,..,Fn}
%Fi(V,CH) - V=venit CH=cheltuieli

%Sa se identificie profitul pt. fiecare firma
%F1 => P1=V1-CH1
%Fn => Pn=Vn=CHn


%firma = f(P,V,CH).
%lista= firme*.
%profit(lista).
profit([]).
profit([f(P,V,CH)|T]) :-
       P is V-CH,
       profit(T).


%LISTA de profituri:
%profit2([f(6000,1000),f(5000,7000)], ListaProfituri).
profit2([],[]).
profit2([f(V,CH)|T], [P|ListaProfituri]) :-
       P is V-CH,
       profit2(T, ListaProfituri).



%listaElevi, 3 note, listaMedii
%elevi([e(3,4,5),e(4,5,6)], ListaMedii).
%ListaMedii = [4, 5].
elevi([],[]).
elevi([e(N1,N2,N3)|T],[Media|ListaMedii]) :-
    Media is (N1+N2+N3)/3,
    elevi(T,ListaMedii).