import jellyfish


def FindBest(source, text, keys=['name'],print_=False):
    """
    Given a dictionary and a text, find the best matched item from the dictionary using the name
    :param source: The dictionary to search from (i.e. units, gears, jobs, etc)
    :type source: dict
    :param text: String to find the match
    :type text: str
    :return: The best matched item from the dictionary
    :rtype: dict
    """
    text=text.title()
    # XXX: Purposely shadowing the text parameter
    # Calculate the match score for each key in the source dictionary using the input text.
    # Then, create a list of (key, the best score) tuples.
    if 1:
        similarities = [
            (key, jellyfish.jaro_winkler(text, item[val].title()))
            for key,item in source.items()
            for val in keys
            if val in item
        ]

        # Find the key with the highest score (This is the best matched key)
        key, score = max(similarities, key=lambda s: s[1])

        # XXX: If needed, implement a minimum threshold here

        # Return the actual best-matched value
        best_match = source[key]
        if print_:
            print("{name} is the best match for input '{input}' with score of {score}".format(
                name=best_match.get('name'), input=text, score=score
            ))
    return key
