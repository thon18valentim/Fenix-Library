using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace Fenix.Animations
{
	public class Anime
	{
		public IEnumerator FadeOut(Graphic graphic, float fadeDuration = 1f)
		{
			Color originalColor = graphic.color;

			float elapsed = 0f;

			while (elapsed < fadeDuration)
			{
				// Calcula o valor interpolado para o fade-out
				float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

				// Define a nova cor do objeto com alpha ajustado
				graphic.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

				// Incrementa o tempo decorrido
				elapsed += Time.deltaTime;

				// Pausa a execução até o próximo frame
				yield return null;
			}

			// Garante que a cor final seja completamente transparente
			graphic.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
		}

		public IEnumerator FadeIn(Graphic graphic, float fadeDuration = 1f)
		{
			Color originalColor = graphic.color;

			float elapsed = 0f;

			while (elapsed < fadeDuration)
			{
				// Calcula o valor interpolado para o fade-in
				float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);

				// Define a nova cor do objeto com alpha ajustado
				graphic.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

				// Incrementa o tempo decorrido
				elapsed += Time.deltaTime;

				// Pausa a execução até o próximo frame
				yield return null;
			}

			// Garante que a cor final seja completamente opaca
			graphic.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
		}
	}
}

