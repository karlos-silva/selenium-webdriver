Funcionalidade: Carrinho de Compras

Cenário: Carrinho Vazio
	Dado Que o usuário esteja na página de login
	E Informar as credenciais corretamente
	E que o usuário está no carrinho de compras
	Quando usuário não adicionar itens no carrinho
	E Clicar no botão checkout
	Então O sistema não solicitará as os dados de entrega

	
Esquema do Cenário: Carrinho com itens
	Dado Que o usuário esteja na página de login
	Quando Informar as credenciais corretamente
	E que o usuário adicionou no carrinho uma "<quantidade>":
	E Clicar no botão checkout
	Então O sistema solicitará as os dados de entrega

	Exemplos: 
		| quantidade |
		|      1     |
		|      3     |

	