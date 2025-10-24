import 'package:flutter/material.dart';

import '../../common/cards/content_card.dart';

class PatientSearchBar extends StatefulWidget {
  const PatientSearchBar({super.key});

  @override
  State<PatientSearchBar> createState() => _PatientSearchBarState();
}

class _PatientSearchBarState extends State<PatientSearchBar> {
  @override
  Widget build(BuildContext context) {
    return ContentCard(
      child: SearchBar(leading: Icon(Icons.search_rounded), hintText: "Search...", onTap: () => {
      },),
    );
  }
}
