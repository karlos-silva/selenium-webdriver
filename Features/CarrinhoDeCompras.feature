Funcionalidade: Carrinho de Compras

Cenário: Carrinho Vazio
	Dado que o usuário está no carrinho de compras
	E que o usuário não adicionou itens no carrinho
	Quando Clicar no botão checkout
	Então O sistema solicitará as os dados de entrega

	
Esquema do Cenário: Carrinho com itens
	Dado que o usuário está no carrinho de compras
	E que o usuário adicionou no carrinho uma "<quantidade>":
	Quando Clicar no botão checkout
	Então O sistema solicitará as os dados de entrega

	Exemplos: 
		| quantidade |
		|      1     |
		|      3     |

	