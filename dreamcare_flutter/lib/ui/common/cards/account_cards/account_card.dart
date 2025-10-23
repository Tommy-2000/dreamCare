import 'package:flutter/material.dart';
import '../content_card.dart';

class AccountCard extends StatefulWidget {
  const AccountCard({super.key});

  @override
  State createState() => _AccountCardState();
}

class _AccountCardState extends State<AccountCard> {
  @override
  Widget build(BuildContext context) {
    return ContentCard(child: Text("Account Card"));
  }
}
