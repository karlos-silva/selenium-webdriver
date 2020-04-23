Funcionalidade: LoginFeature


	Cenario: Login Correto
		Dado Que o usuário esteja na página de login
		Quando Informar as credenciais corretamente
		Então Sera redirecionado para a tela de Produtos

	Esquema do Cenario: Login Incorreto 
		Dado Que o usuário esteja na página de login
		Quando Informar as credenciais "<incorretamente>"
		Então Será exibida uma mensagem informando o erro

	Exemplos: 
		| incorretamente     |
		| username vazio     |
		| username invalido  |
		| password vazio     |
		| password invalido |


